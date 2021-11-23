using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class UpdateAnnouncementsCommand : CommandBase
    {
        private readonly AnnouncemetsDeskViewModel _announcemetsDeskViewModel;
        public override void Execute(object parameter)
        {
            _announcemetsDeskViewModel.Announcements = AnnouncementService.GetAllAnnouncements();
        }

        public UpdateAnnouncementsCommand(AnnouncemetsDeskViewModel announcemetsDeskViewModel)
        {
            _announcemetsDeskViewModel = announcemetsDeskViewModel;
            
        }
    }
}
