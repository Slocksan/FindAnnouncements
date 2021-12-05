using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class ApplyAnnouncementFilterCommand : CommandBase
    {
        private readonly EditAnnouncementFilterViewModel _editAnnouncementFilterViewModel;

        public override void Execute(object parameter)
        {
            _editAnnouncementFilterViewModel.AnnouncementFilter.AnimalCategory =
                _editAnnouncementFilterViewModel.AnimalCategory;
            _editAnnouncementFilterViewModel.AnnouncementFilter.Gender = _editAnnouncementFilterViewModel.Gender;
            _editAnnouncementFilterViewModel.AnnouncementFilter.IsUsedDateFilter =
                _editAnnouncementFilterViewModel.IsUsedDateFilter;
            _editAnnouncementFilterViewModel.AnnouncementFilter.StartDate = _editAnnouncementFilterViewModel.StartDate;
            _editAnnouncementFilterViewModel.AnnouncementFilter.EndDate = _editAnnouncementFilterViewModel.EndDate;

            ((Window)parameter).DialogResult = true;
        }

        public ApplyAnnouncementFilterCommand(EditAnnouncementFilterViewModel editAnnouncementFilterViewModel)
        {
            _editAnnouncementFilterViewModel = editAnnouncementFilterViewModel;
        }
    }
}
