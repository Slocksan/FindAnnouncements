using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class EditAnnouncementFilterCommand : CommandBase
    {
        private readonly BaseAnnouncementDeskViewModel _announcementDeskViewModel;

        public override void Execute(object parameter)
        {
            if(_announcementDeskViewModel.AnnouncementsFilter == null)
                return;

            var announcementFilter = _announcementDeskViewModel.AnnouncementsFilter;
            var editAnnouncementFilterView = new EditAnnouncementFilterView();
            editAnnouncementFilterView.DataContext = new EditAnnouncementFilterViewModel(_announcementDeskViewModel.AnnouncementsFilter);
            editAnnouncementFilterView.ShowDialog();

            if (editAnnouncementFilterView.DialogResult == true) 
                _announcementDeskViewModel.AnnouncementsFilter = announcementFilter;
        }

        public EditAnnouncementFilterCommand(BaseAnnouncementDeskViewModel announcementDeskViewModel)
        {
            _announcementDeskViewModel = announcementDeskViewModel;
        }
    }
}
