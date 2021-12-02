using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FindAnnouncements.Commands;
using FindAnnouncements.Enums;
using Microsoft.Win32;
using static FindAnnouncements.Enums.WorkWithEnumExtansion;

namespace FindAnnouncements.ViewModel
{
    class WorkWithAnnouncementViewModel : BaseViewModel
    {
        public Announcement Announcement { get; }
        public User User { get; }
        public List<string> AnimalTypes { get;}
        public List<string> Genders { get;}

        private bool _dialogResult;

        public bool DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                _dialogResult = value;
                OnPropertyChanged(nameof(DialogResult));
            }
        }

        private byte[] _photo;

        public byte[] Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        private string _animalName;

        public string AnimalName
        {
            get
            {
                return _animalName;
            }
            set
            {
                _animalName = value;
                OnPropertyChanged(nameof(AnimalName));
            }
        }

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _location;

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private string _animalCategory;

        public string AnimalCategory
        {
            get
            {
                return _animalCategory;
            }
            set
            {
                _animalCategory = value;
                OnPropertyChanged(nameof(AnimalCategory));
            }
        }

        private string _gender;

        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        private bool? _chipped;

        public bool? Chipped
        {
            get
            {
                return _chipped;
            }
            set
            {
                _chipped = value;
                OnPropertyChanged(nameof(Chipped));
            }
        }

        private DateTime _publishTime;

        public DateTime PublishTime
        {
            get
            {
                return _publishTime;
            }
            set
            {
                _publishTime = value;
                OnPropertyChanged(nameof(PublishTime));
            }
        }

        public WorkWithAnnouncementViewModel(Announcement announcement, User user)
        {
            Announcement = announcement;
            User = user;
            AnimalTypes = GetListOfEnumsDescriptions<AnimalType>();
            Genders = GetListOfEnumsDescriptions<Gender>();

            AnimalCategory = Announcement.AnimalCategory;
            AnimalName = Announcement.AnimalName;
            Gender = Announcement.Gender;
            Chipped = Announcement.Chiped;
            PublishTime = Announcement.PublishDate;
            Location = Announcement.Location;
            Description = Announcement.Discription;

            LoadPhotoCommand = new LoadPhotoCommand(this);
            ApplyCommand = new ApplyEditedAnnouncementCommand(this);
        }

        public ICommand LoadPhotoCommand { get; }
        public ICommand ApplyCommand { get; }
    }
}
