using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class EditAnnouncementCommand : CommandBase
    {
        private readonly User _user;
        private readonly ICommand _updateCommand;

        public override void Execute(object parameter)
        {
            var announcementToEdit = parameter as Announcement;
            var workWithAnnounWindow = new WorkWithAnnouncementView();
            workWithAnnounWindow.DataContext = new WorkWithAnnouncementViewModel(announcementToEdit, _user);
            workWithAnnounWindow.ShowDialog();
            if (workWithAnnounWindow.DialogResult == true)
            {
                AnnouncementService.EditAnnouncement(announcementToEdit);
                Authorization.Journaling(_user, "Изменение объявления", $"Изменено объявление #{announcementToEdit.AnnounID}");
                _updateCommand.Execute(null);
            }
        }

        public EditAnnouncementCommand(User user, ICommand updateCommand)
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
