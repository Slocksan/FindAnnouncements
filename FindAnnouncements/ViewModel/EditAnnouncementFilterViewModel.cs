using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FindAnnouncements.Commands;
using FindAnnouncements.Enums;
using FindAnnouncements.Models;
using static FindAnnouncements.Enums.WorkWithEnumExtension;

namespace FindAnnouncements.ViewModel
{
    class EditAnnouncementFilterViewModel : BaseViewModel, INotifyDataErrorInfo
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

                _propertyNameToErrorsDictionary.Remove(nameof(StartDate));
                _propertyNameToErrorsDictionary.Remove(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    var startDateErrors = new List<string>()
                    {
                        "Начало временого интервала не может быть позже конца"
                    };
                    _propertyNameToErrorsDictionary.Add(nameof(StartDate), startDateErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(StartDate)));
                }

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

                _propertyNameToErrorsDictionary.Remove(nameof(StartDate));
                _propertyNameToErrorsDictionary.Remove(nameof(EndDate));

                if (EndDate < StartDate)
                {
                    var endDateErrors = new List<string>()
                    {
                        "Конец временого интервала не может быть раньше начала"
                    };
                    _propertyNameToErrorsDictionary.Add(nameof(EndDate), endDateErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(EndDate)));
                }

                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand ApplyFiltersCommand { get; }
        public EditAnnouncementFilterViewModel(AnnouncementFilter announcementFilter)
        {
            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();

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

        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public IEnumerable GetErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.TryGetValue(propertyName, out var errors);
            return errors ?? new List<string>();
        }

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }
}
