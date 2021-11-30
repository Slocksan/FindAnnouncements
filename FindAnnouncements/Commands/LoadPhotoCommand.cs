using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.ViewModel;
using Microsoft.Win32;

namespace FindAnnouncements.Commands
{
    class LoadPhotoCommand : CommandBase
    {
        private readonly WorkWithAnnouncementViewModel _viewModel;

        public override void Execute(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите фото";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                    "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() != true)
                return;
            var fileName = openFileDialog.FileName;
            _viewModel.Photo = File.ReadAllBytes(fileName);
        }

        public LoadPhotoCommand(WorkWithAnnouncementViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}
