using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class UpdateAnnouncementsCommand : CommandBase
    {
        private readonly BaseAnnouncementDeskViewModel _viewModel;

        public UpdateAnnouncementsCommand(BaseAnnouncementDeskViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {

            _viewModel.Announcements = 
                AnnouncementService.GetAnnouncements(_viewModel.AnnouncementsFilter.FilterExpression,
                    _viewModel.SelectedAnnouncementSorter.SorterExpression);
        }
    }
}
