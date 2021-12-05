using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class UpdateAnnouncementsCommand : CommandBase
    {
        private readonly BaseAnnouncementDeskViewModel _announcementDeskViewModel;

        public override void Execute(object parameter)
        {

            _announcementDeskViewModel.Announcements = 
                AnnouncementService.GetAllAnnouncements(_announcementDeskViewModel.AnnouncementsFilter.FilterExpression,
                    _announcementDeskViewModel.SelectedAnnouncementSorter.SorterExpression);
        }

        public UpdateAnnouncementsCommand(BaseAnnouncementDeskViewModel announcementDeskViewModel)
        {
            _announcementDeskViewModel = announcementDeskViewModel;
        }
    }
}
