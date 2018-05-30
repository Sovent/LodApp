using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LodApp.Extensions;
using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class AddParticipantViewModel : ParameterizedViewModel<ObservableCollection<ProjectDeveloperViewModel>>
	{
		public AddParticipantViewModel(IDevelopersService developersService)
		{
			_developersService = developersService;
			AddUserCommand = new Command(async () => await AddDeveloperToProject());
		}

		public override void Prepare(ObservableCollection<ProjectDeveloperViewModel> projectDevelopers)
		{
			ProjectDevelopers = projectDevelopers;
			FoundDevelopers = new ObservableCollection<ProjectDeveloperViewModel>();
			Role = string.Empty;
			PropertyChanged += async (sender, args) =>
			{
				if (args.PropertyName != nameof(SearchString))
				{
					return;
				}

				await SearchDevelopers();
			};
		}

		public override Task InitializeAsync()
		{
			SearchString = string.Empty;
			return Task.CompletedTask;
		}

		public ICommand AddUserCommand { get; }
		public ObservableCollection<ProjectDeveloperViewModel> FoundDevelopers
		{
			get => _foundDevelopers;
			set => SetValue(ref _foundDevelopers, value);
		}

		public ObservableCollection<ProjectDeveloperViewModel> ProjectDevelopers
		{
			get => _projectDevelopers;
			set => SetValue(ref _projectDevelopers, value);
		}

		public string SearchString
		{
			get => _searchString;
			set => SetValue(ref _searchString, value);
		}

		public string Role
		{
			get => _role;
			set => SetValue(ref _role, value);
		}

		public ProjectDeveloperViewModel SelectedDeveloper
		{
			get => _selectedDeveloper;
			set => SetValue(ref _selectedDeveloper, value);
		}

		private async Task AddDeveloperToProject()
		{
			ProjectDevelopers.Add(SelectedDeveloper);
			SelectedDeveloper = null;
			Role = string.Empty;
			await SearchDevelopers();
		}

		private async Task SearchDevelopers()
		{
			var developers = await _developersService.SearchDevelopers(SearchString);
			var foundDevelopers = developers.ToViewModel();
			var applicableDevelopers = foundDevelopers.Where(foundDeveloper =>
				_projectDevelopers.All(projectDeveloper => projectDeveloper.Id != foundDeveloper.Id));
			_foundDevelopers = new ObservableCollection<ProjectDeveloperViewModel>(applicableDevelopers);
		}

		private readonly IDevelopersService _developersService;
		private string _role;
		private string _searchString;
		private ProjectDeveloperViewModel _selectedDeveloper;
		private ObservableCollection<ProjectDeveloperViewModel> _foundDevelopers;
		private ObservableCollection<ProjectDeveloperViewModel> _projectDevelopers;
	}
}