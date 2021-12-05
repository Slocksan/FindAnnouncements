using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class ApplyEditedAnnouncementCommand : CommandBase
    {
        private readonly WorkWithAnnouncementViewModel _workWithAnnouncementViewModel;

        public ApplyEditedAnnouncementCommand(WorkWithAnnouncementViewModel workWithAnnouncementViewModel)
        {
            _workWithAnnouncementViewModel = workWithAnnouncementViewModel;
        }

        public override void Execute(object parameter)
        {
            _workWithAnnouncementViewModel.Announcement.AnimalCategory = _workWithAnnouncementViewModel.AnimalCategory;
            _workWithAnnouncementViewModel.Announcement.AnimalName = _workWithAnnouncementViewModel.AnimalName;
            _workWithAnnouncementViewModel.Announcement.Chiped = _workWithAnnouncementViewModel.Chipped;
            _workWithAnnouncementViewModel.Announcement.Discription = _workWithAnnouncementViewModel.Description;
            _workWithAnnouncementViewModel.Announcement.Location = _workWithAnnouncementViewModel.Location;
            _workWithAnnouncementViewModel.Announcement.Photo = _workWithAnnouncementViewModel.Photo;
            _workWithAnnouncementViewModel.Announcement.Gender = _workWithAnnouncementViewModel.Gender;
            _workWithAnnouncementViewModel.Announcement.UserID = _workWithAnnouncementViewModel.User.UserID;

            ((Window) parameter).DialogResult = true;
        }
    }
}
