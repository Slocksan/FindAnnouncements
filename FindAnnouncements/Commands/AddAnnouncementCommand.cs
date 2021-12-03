using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Models;
using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class AddAnnouncementCommand : CommandBase
    {
        private readonly User _user;
        private readonly ICommand _updateCommand;

        public override void Execute(object parameter)
        {
            var workWithAnnounWindow = new WorkWithAnnouncementView();

            var announcementToAdd = new Announcement();
            workWithAnnounWindow.DataContext = new WorkWithAnnouncementViewModel(announcementToAdd, _user);
            workWithAnnounWindow.ShowDialog();
            if (workWithAnnounWindow.DialogResult == true)
            {
                AnnouncementService.AddAnnouncement(announcementToAdd);
                var addedAnnouncement = AnnouncementService.GetAllAnnouncements(announ => announ.UserID == _user.UserID).Last();
                Authorization.Journaling(_user, "Добавление объявления", $"Добавлено объявление #{addedAnnouncement.AnnounID}");
                _updateCommand.Execute(null);
            }
        }

        public AddAnnouncementCommand(User user, ICommand updateCommand)
        {
            _user = user;
            _updateCommand = updateCommand;
        }

        public void ViewModelOnPropertyChanged()
        {
            OnCanExecutedChanged();
        }
    }
}
