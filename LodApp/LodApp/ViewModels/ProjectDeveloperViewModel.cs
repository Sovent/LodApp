using System;
using System.Windows.Input;
using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class ProjectDeveloperViewModel : BaseViewModel
	{
		public ProjectDeveloperViewModel(
			int id,
			string displayName, 
			string roleInProject,
			ICommand deleteDeveloperCommand)
		{
			_roleInProject = roleInProject ?? throw new ArgumentNullException(nameof(roleInProject));
			_displayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
			_id = id;
			DeleteDeveloperCommand = deleteDeveloperCommand;
		}

		public ICommand GoToDeveloperCommand { get; }
		public ICommand DeleteDeveloperCommand { get; }

		public int Id
		{
			get => _id;
			set => SetValue(ref _id, value);
		}

		public int ProjectId
		{
			get => _projectId;
			set => SetValue(ref _projectId, value);
		}

		public string DisplayName
		{
			get => _displayName;
			set => SetValue(ref _displayName, value);
		}

		public string RoleInProject
		{
			get => _roleInProject;
			set => SetValue(ref _roleInProject, value);
		}
		
		private string _roleInProject;
		private string _displayName;
		private int _id;
		private int _projectId;
	}
}