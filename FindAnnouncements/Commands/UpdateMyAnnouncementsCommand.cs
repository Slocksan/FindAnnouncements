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
    class UpdateMyAnnouncementsCommand : CommandBase
    {
        private readonly MyAnnouncementsViewModel _myAnnouncementsViewModel;

        public override void Execute(object parameter)
        {
            _myAnnouncementsViewModel.Announcements = AnnouncementService.GetAllAnnouncements(announcement =>
                announcement.UserID == _myAnnouncementsViewModel.AuthorizationStore.ActualAuthorization.User.UserID);
        }

        public UpdateMyAnnouncementsCommand(MyAnnouncementsViewModel myAnnouncementsViewModel)
        {
            _myAnnouncementsViewModel = myAnnouncementsViewModel;
        }
    }
}
