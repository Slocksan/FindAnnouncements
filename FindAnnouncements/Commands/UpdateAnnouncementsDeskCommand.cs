using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Models;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class UpdateAnnouncementsDeskCommand : CommandBase
    {
        private readonly AnnouncemetsDeskViewModel _announcemetsDeskViewModel;

        public override void Execute(object parameter)
        {
            var typeOfGeneric = _announcemetsDeskViewModel.SelectedAnnouncementSorter.GetTypeOfGeneric();
            switch (typeOfGeneric.Name)
            {
                case "String":
                    _announcemetsDeskViewModel.Announcements = AnnouncementService.GetAllAnnouncements(((AnnouncementSorter<string>)_announcemetsDeskViewModel.SelectedAnnouncementSorter).SorterExpression);
                    break;
                case "DateTime":
                    _announcemetsDeskViewModel.Announcements = AnnouncementService.GetAllAnnouncements(((AnnouncementSorter<DateTime>)_announcemetsDeskViewModel.SelectedAnnouncementSorter).SorterExpression);
                    break;
            }
            
        }

        public UpdateAnnouncementsDeskCommand(AnnouncemetsDeskViewModel announcemetsDeskViewModel)
        {
            _announcemetsDeskViewModel = announcemetsDeskViewModel;
        }
    }
}
