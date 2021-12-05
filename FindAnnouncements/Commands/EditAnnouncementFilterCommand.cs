using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class EditAnnouncementFilterCommand : CommandBase
    {
        private readonly BaseAnnouncementDeskViewModel _viewModel;
        
        public EditAnnouncementFilterCommand(BaseAnnouncementDeskViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.AnnouncementsFilter == null)
                return;

            var announcementFilter = _viewModel.AnnouncementsFilter;
            var editAnnouncementFilterView = new EditAnnouncementFilterView();
            editAnnouncementFilterView.DataContext = new EditAnnouncementFilterViewModel(_viewModel.AnnouncementsFilter);
            editAnnouncementFilterView.ShowDialog();

            if (editAnnouncementFilterView.DialogResult == true) 
                _viewModel.AnnouncementsFilter = announcementFilter;
        }
    }
}
