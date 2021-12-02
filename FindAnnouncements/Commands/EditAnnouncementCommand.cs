﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;
using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class EditAnnouncementCommand : CommandBase
    {
        private readonly User _user;
        public override void Execute(object parameter)
        {
            var announcementToEdit = parameter as Announcement;
            var workWithAnnounWindow = new WorkWithAnnouncementView();
            workWithAnnounWindow.DataContext = new WorkWithAnnouncementViewModel(announcementToEdit, _user);
            workWithAnnounWindow.ShowDialog();
            if (workWithAnnounWindow.DialogResult == true)
                AnnouncementService.EditAnnouncement(announcementToEdit);
        }

        public EditAnnouncementCommand(User user)
        {
            _user = user;
        }

        public void ViewModelOnPropertyChanged()
        {
            OnCanExecutedChanged();
        }
    }
}
