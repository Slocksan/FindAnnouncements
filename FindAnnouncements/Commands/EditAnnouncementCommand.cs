using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.View;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements.Commands
{
    class EditAnnouncementCommand : CommandBase
    {
        private readonly User _user;
        public override void Execute(object parameter)
        {
            var workWithAnnounWindow = new WorkWithAnnouncementView();
            workWithAnnounWindow.DataContext = new WorkWithAnnouncementViewModel(parameter as Announcement, _user);
            workWithAnnounWindow.ShowDialog();
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
