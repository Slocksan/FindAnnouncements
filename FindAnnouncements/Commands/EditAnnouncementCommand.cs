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

        public EditAnnouncementCommand(User user, ICommand updateCommand)
        {
            _user = user;
            _updateCommand = updateCommand;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Announcement announcementToEdit)
            {
                var workWithAnnouncementView = new WorkWithAnnouncementView();

                workWithAnnouncementView.DataContext = new WorkWithAnnouncementViewModel(announcementToEdit, _user);
                workWithAnnouncementView.ShowDialog();
                if (workWithAnnouncementView.DialogResult == true)
                {
                    AnnouncementService.EditAnnouncement(announcementToEdit);
                    Authorization.Journaling(_user, "Изменение объявления", $"Объявление #{announcementToEdit.AnnounID}");
                    _updateCommand.Execute(null);
                }
            }
        }
    }
}
