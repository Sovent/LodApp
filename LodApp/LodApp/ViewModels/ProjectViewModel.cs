using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using LodApp.Converters;
using LodApp.DataAccess.DTO;
using LodApp.Extensions;
using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class ProjectViewModel : ParameterizedViewModel<int>
	{
		static ProjectViewModel()
		{
			var valueConverter = new ProjectStatusStringConverter();
			ProjectStatuses = new ObservableCollection<string>(
				Enum.GetValues(typeof(ProjectStatus))
					.Cast<ProjectStatus>()
					.Select(status => valueConverter.Convert(status, typeof(string), null, CultureInfo.CurrentUICulture))
					.Cast<string>());
		}

		public ProjectViewModel(
			IProjectsService projectsService, 
			IUserDialogs userDialogs, 
			INavigationService navigationService)
		{
			_userDialogs = userDialogs ?? throw new ArgumentNullException(nameof(userDialogs));
			_projectsService = projectsService ?? throw new ArgumentNullException(nameof(projectsService));
			DeleteDeveloperCommand = new Command(async (developerViewModel) => await DeleteDeveloperAsync(developerViewModel));
			SaveProject = new Command(async () => await SaveProjectAsync());
			AddDeveloperCommand = new Command(async () => await navigationService
				.NavigateModalAsync<AddParticipantViewModel, ObservableCollection<ProjectDeveloperViewModel>>(Developers));
		}

		public override void Prepare(int projectId)
		{
			ProjectId = projectId;
		}

		public override async Task InitializeAsync()
		{
			var project = await _projectsService.GetProject(ProjectId);
			ProjectName = project.Name;
			ProjectStatus = project.ProjectStatus;
			Image = project.LandingImage == null
				? ImageSource.FromResource("LodApp.Images.project-cap-image.png")
				: ImageSource.FromUri(project.LandingImage.BigPhotoUri);
			Description = project.Info;
			RepositoriesUrl = new ObservableCollection<string>(project.LinksToGithubRepositories.Select(link => link.ToString()));
			Developers = new ObservableCollection<ProjectDeveloperViewModel>(
				project.ProjectMemberships.Select(membership => membership.ToViewModel(project.ProjectId, this)));
			Screenshots = new ObservableCollection<ImageSource>(
				project.Screenshots.Select(screen => ImageSource.FromUri(screen.BigPhotoUri)));
			IsGame = project.ProjectType.Contains(ProjectType.Game);
			IsDesktop = project.ProjectType.Contains(ProjectType.Desktop);
			IsMobile = project.ProjectType.Contains(ProjectType.MobileApp);
			IsWeb = project.ProjectType.Contains(ProjectType.Website);
			IsOther = project.ProjectType.Contains(ProjectType.Other);
		}

		public ICommand AddDeveloperCommand { get; }
		public ICommand DeleteDeveloperCommand { get; }
		public ICommand SaveProject { get; }
		public int ProjectId
		{
			get => _projectId;
			set => SetValue(ref _projectId, value);
		}

		public string ProjectName
		{
			get => _projectName;
			set => SetValue(ref _projectName, value);
		}

		public ProjectStatus ProjectStatus
		{
			get => _projectStatus;
			set => SetValue(ref _projectStatus, value);
		}

		public ImageSource Image
		{
			get => _image;
			set => SetValue(ref _image, value);
		}

		public string Description
		{
			get => _description;
			set => SetValue(ref _description, value);
		}

		public static ObservableCollection<string> ProjectStatuses;

		public ObservableCollection<string> RepositoriesUrl
		{
			get => _repositoriesUrl;
			set => SetValue(ref _repositoriesUrl, value);
		}

		public ObservableCollection<ProjectDeveloperViewModel> Developers
		{
			get => _developers;
			set => SetValue(ref _developers, value);
		}

		public ObservableCollection<ImageSource> Screenshots
		{
			get => _screenshots;
			set => SetValue(ref _screenshots, value);
		}

		public bool IsMobile
		{
			get => _isMobile;
			set => SetValue(ref _isMobile, value);
		}

		public bool IsWeb
		{
			get => _isWeb;
			set => SetValue(ref _isWeb, value);
		}

		public bool IsDesktop
		{
			get => _isDesktop;
			set => SetValue(ref _isDesktop, value);
		}

		public bool IsGame
		{
			get => _isGame;
			set => SetValue(ref _isGame, value);
		}

		public bool IsOther
		{
			get => _isOther;
			set => SetValue(ref _isOther, value);
		}

		private async Task DeleteDeveloperAsync(object developerViewModel)
		{
			if (!(developerViewModel is ProjectDeveloperViewModel developer))
			{
				return;
			}

			await _projectsService.DeleteDeveloperFromProject(developer.ProjectId, developer.Id);
			_developers.Remove(developer);
		}

		private async Task SaveProjectAsync()
		{
			var dialog = _userDialogs.Loading("Сохранение проекта");
			var request = this.ToUpdateRequest();
			var result = await _projectsService.UpdateProject(ProjectId, request);
			dialog.Hide();
			_userDialogs.Toast(result.IsError ? result.ErrorMessage : result.Value);
		}

		private ObservableCollection<ProjectDeveloperViewModel> _developers;
		private ObservableCollection<string> _repositoriesUrl;
		private string _projectName;
		private ProjectStatus _projectStatus;
		private int _projectId;
		private bool _isOther;
		private bool _isGame;
		private bool _isDesktop;
		private bool _isWeb;
		private bool _isMobile;
		private string _description;
		private ImageSource _image;
		private ObservableCollection<ImageSource> _screenshots;
		private readonly IProjectsService _projectsService;
		private readonly IUserDialogs _userDialogs;
	}
}