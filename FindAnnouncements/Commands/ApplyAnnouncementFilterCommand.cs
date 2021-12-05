using System.Windows;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class ApplyAnnouncementFilterCommand : CommandBase
    {
        private readonly EditAnnouncementFilterViewModel _viewModel;

        public ApplyAnnouncementFilterCommand(EditAnnouncementFilterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.AnnouncementFilter.AnimalCategory = _viewModel.AnimalCategory;
            _viewModel.AnnouncementFilter.Gender = _viewModel.Gender;
            _viewModel.AnnouncementFilter.IsUsedDateFilter = _viewModel.IsUsedDateFilter;
            _viewModel.AnnouncementFilter.StartDate = _viewModel.StartDate;
            _viewModel.AnnouncementFilter.EndDate = _viewModel.EndDate;

            if(parameter != null)
                ((Window)parameter).DialogResult = true;
        }
    }
}
