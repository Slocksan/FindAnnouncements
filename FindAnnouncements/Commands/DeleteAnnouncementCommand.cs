using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindAnnouncements.Models;

namespace FindAnnouncements.Commands
{
    public class DeleteAnnouncementCommand :  CommandBase
    {
        private readonly User _user;
        private readonly ICommand _updateCommand;

        public override void Execute(object parameter)
        {
            if (parameter is Announcement)
            {
                AnnouncementService.DeleteAnnouncement((Announcement)parameter);
                Authorization.Journaling(_user, "Удаление объявления", $"Удалено объявление #{((Announcement)parameter).AnnounID}");
                _updateCommand.Execute(null);
            }
        }

        public DeleteAnnouncementCommand(User user, ICommand updateCommand)
        {
            _user = user;
            _updateCommand = updateCommand;
        }
    }
}
