using LodApp.Service;
using Xamarin.Forms;

namespace LodApp.ViewModels
{
	public class DeveloperViewModel : ParameterizedViewModel<int>
	{
		public DeveloperViewModel(IDevelopersService developersService)
		{
			_developersService = developersService;
		}

		public override void Prepare(int developerId)
		{
			DeveloperId = developerId;
		}

		public int DeveloperId
		{
			get => _developerId;
			set => SetValue(ref _developerId, value);
		}

		public ImageSource Avatar
		{
			get => _avatar;
			set => SetValue(ref _avatar, value);
		}

		public string Institute
		{
			get => _institute;
			set => SetValue(ref _institute, value);
		}

		public string StudyingDirection
		{
			get => _studyingDirection;
			set => SetValue(ref _studyingDirection, value);
		}

		public bool IsGraduated
		{
			get => _isGraduated;
			set => SetValue(ref _isGraduated, value);
		}

		private bool _isGraduated;
		private string _studyingDirection;
		private string _institute;
		private ImageSource _avatar;

		private readonly IDevelopersService _developersService;
		private int _developerId;
	}
}