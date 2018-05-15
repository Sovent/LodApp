using System.Collections.ObjectModel;
using LodApp.Service;

namespace LodApp.ViewModels
{
	public class ProjectViewModel : BaseViewModel
	{
		public ProjectViewModel(IProjectsService projectsService)
		{
			_projectsService = projectsService;
			_repositoriesUrl = new ObservableCollection<string>
			{
				"https://github.com/LeagueOfDevelopers/ItHappened",
				"https://github.com/LeagueOfDevelopers/ItHappened"
			};
		}

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

		public ObservableCollection<string> RepositoriesUrl
		{
			get => _repositoriesUrl;
			set => SetValue(ref _repositoriesUrl, value);
		}

		private ObservableCollection<string> _repositoriesUrl;
		private string _projectName;
		private int _projectId;
		private readonly IProjectsService _projectsService;
	}
}