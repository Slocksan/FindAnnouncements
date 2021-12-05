using System.Windows.Input;
using FindAnnouncements.Models;

namespace FindAnnouncements.Commands
{
    public class DeleteAnnouncementCommand :  CommandBase
    {
        private readonly User _user;
        private readonly ICommand _updateCommand;

        public DeleteAnnouncementCommand(User user, ICommand updateCommand)
        {
            _user = user;
            _updateCommand = updateCommand;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Announcement announcement)
            {
                AnnouncementService.DeleteAnnouncement(announcement);
                Authorization.Journaling(_user, "Удаление объявления", $"Удалено объявление #{announcement.AnnounID}");
                _updateCommand.Execute(null);
            }
        }
    }
}
