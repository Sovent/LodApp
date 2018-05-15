using System;
using LodApp.DataAccess.DTO;

namespace LodApp.ViewModels
{
	public class ProjectItemViewModel : BaseViewModel
	{
		public ProjectItemViewModel(bool isOther, bool isGame, bool isDesktop, bool isWeb, bool isMobile,
			ProjectStatus projectStatus, string projectName, int projectId)
		{
			_isOther = isOther;
			_isGame = isGame;
			_isDesktop = isDesktop;
			_isWeb = isWeb;
			_isMobile = isMobile;
			_projectStatus = projectStatus;
			_projectName = projectName ?? throw new ArgumentNullException(nameof(projectName));
			_projectId = projectId;
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

		public ProjectStatus ProjectStatus
		{
			get => _projectStatus;
			set => SetValue(ref _projectStatus, value);
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

		private bool _isOther;
		private bool _isGame;
		private bool _isDesktop;
		private bool _isWeb;
		private bool _isMobile;
		private ProjectStatus _projectStatus;
		private string _projectName;
		private int _projectId;
	}
}