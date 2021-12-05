using System.Windows;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class ApplyEditedAnnouncementCommand : CommandBase
    {
        private readonly WorkWithAnnouncementViewModel _viewModel;

        public ApplyEditedAnnouncementCommand(WorkWithAnnouncementViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Announcement.AnimalCategory = _viewModel.AnimalCategory;
            _viewModel.Announcement.AnimalName = _viewModel.AnimalName;
            _viewModel.Announcement.Chiped = _viewModel.Chipped;
            _viewModel.Announcement.Discription = _viewModel.Description;
            _viewModel.Announcement.Location = _viewModel.Location;
            _viewModel.Announcement.Photo = _viewModel.Photo;
            _viewModel.Announcement.Gender = _viewModel.Gender;
            _viewModel.Announcement.UserID = _viewModel.User.UserID;

            if (parameter != null)
                ((Window)parameter).DialogResult = true;
        }
    }
}
