using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class AddAnnouncementCommand : CommandBase
    {
        private readonly User _user;
        public override void Execute(object parameter)
        {
            var workWithAnnounWindow = new WorkWithAnnouncementView();

            var announcementToAdd = new Announcement();
            workWithAnnounWindow.DataContext = new WorkWithAnnouncementViewModel(announcementToAdd, _user);
            workWithAnnounWindow.ShowDialog();
            if(workWithAnnounWindow.DialogResult == true)
                AnnouncementService.AddAnnouncement(announcementToAdd);
        }

        public AddAnnouncementCommand(User user)
        {
            _user = user;
        }

        public void ViewModelOnPropertyChanged()
        {
            OnCanExecutedChanged();
        }
    }
}
