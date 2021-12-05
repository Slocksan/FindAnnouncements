using System;
using System.Collections.Generic;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Enums;
using FindAnnouncements.Models;
using static FindAnnouncements.Enums.WorkWithEnumExtension;

namespace FindAnnouncements.ViewModel
{
    class EditAnnouncementFilterViewModel : BaseViewModel
    {
        public AnnouncementFilter AnnouncementFilter { get; }
        public List<string> AnimalTypes { get; }
        public List<string> Genders { get; }

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

        private bool _isUsedDateFilter;
        public bool IsUsedDateFilter
        {
            get
            {
                return _isUsedDateFilter;
            }
            set
            {
                _isUsedDateFilter = value;
                OnPropertyChanged(nameof(IsUsedDateFilter));
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand ApplyFiltersCommand { get; }
        public EditAnnouncementFilterViewModel(AnnouncementFilter announcementFilter)
        {
            AnnouncementFilter = announcementFilter;
            AnimalCategory = announcementFilter.AnimalCategory;
            Gender = announcementFilter.Gender;
            IsUsedDateFilter = announcementFilter.IsUsedDateFilter;
            StartDate = announcementFilter.StartDate;
            EndDate = announcementFilter.EndDate;


            Genders = new List<string> {""};
            Genders.AddRange(GetListOfEnumsDescriptions<Gender>());
            AnimalTypes = new List<string> {""};
            AnimalTypes.AddRange(GetListOfEnumsDescriptions<AnimalType>());

            ApplyFiltersCommand = new ApplyAnnouncementFilterCommand(this);
        }
    }
}
