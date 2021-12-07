using System.Linq;
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

        public AddAnnouncementCommand(User user, ICommand updateCommand)
        {
            _user = user;
            _updateCommand = updateCommand;
        }
        public override void Execute(object parameter)
        {
            var workWithAnnouncementView = new WorkWithAnnouncementView();

            var announcementToAdd = new Announcement();
            workWithAnnouncementView.DataContext = new WorkWithAnnouncementViewModel(announcementToAdd, _user);
            workWithAnnouncementView.ShowDialog();
            if (workWithAnnouncementView.DialogResult == true)
            {
                AnnouncementService.AddAnnouncement(announcementToAdd);
                var addedAnnouncement = AnnouncementService.GetAnnouncements($"UserID == \"{_user.UserID}\"", "UserID").Last();
                Authorization.Journaling(_user, "Добавление объявления", $"Объявление #{addedAnnouncement.AnnounID}");
                _updateCommand.Execute(null);
            }
        }
    }
}
