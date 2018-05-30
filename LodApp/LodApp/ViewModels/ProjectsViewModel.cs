using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LodApp.DataAccess.DTO;
using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class ProjectsViewModel : BaseViewModel
	{
		public ProjectsViewModel(IProjectsService projectsService, INavigationService navigationService)
		{
			_projectsService = projectsService;
			_navigationService = navigationService;
			ProjectItems = new ObservableCollection<ProjectItemViewModel>();
			InitializeCommand = new Command(async () => await InitializeAsync());
		}

		public ICommand InitializeCommand { get; }
		public override async Task InitializeAsync()
		{
			IsLoading = true;
			ProjectItems.Clear();
			await LoadMoreAsync();
		}

		public async Task LoadMoreAsync()
		{
			IsLoading = true;
			var projectPreviews = await _projectsService.GetProjects(ProjectItems.Count, ProjectsPageSize);
			var newProjects = projectPreviews.Where(preview => ProjectItems.All(item => item.ProjectId != preview.ProjectId));
			var newItems = newProjects.Select(ToViewModel).ToArray();
			foreach (var viewModel in newItems)
			{
				ProjectItems.Add(viewModel);
			}
			IsLoading = false;
		}

		public async Task GoToProjectDetails(ProjectItemViewModel viewModel)
		{
			await _navigationService.NavigateAsync<ProjectViewModel, int>(viewModel.ProjectId);
		}

		public ObservableCollection<ProjectItemViewModel> ProjectItems
		{
			get => _projectItems;
			set => SetValue(ref _projectItems, value);
		}

		public bool IsLoading
		{
			get => _isLoading;
			set => SetValue(ref _isLoading, value);
		}

		private bool _isLoading;
		private readonly IProjectsService _projectsService;
		private readonly INavigationService _navigationService;
		private ObservableCollection<ProjectItemViewModel> _projectItems;

		private static ProjectItemViewModel ToViewModel(ProjectPreview projectPreview)
		{
			bool ContainsType(ProjectType projectType)
			{
				return projectPreview.ProjectTypes.Contains(projectType);
			}

			return new ProjectItemViewModel(
				isOther: ContainsType(ProjectType.Other), 
				isGame: ContainsType(ProjectType.Game),
				isDesktop: ContainsType(ProjectType.Desktop), 
				isWeb: ContainsType(ProjectType.Website),
				isMobile: ContainsType(ProjectType.MobileApp),
				projectStatus: projectPreview.ProjectStatus, 
				projectName: projectPreview.Name, 
				projectId: projectPreview.ProjectId);
		}

		private const int ProjectsPageSize = 5;
	}
}