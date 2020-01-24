using SQLite_sample.Annotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library_sample;

namespace SQLite_sample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private ObservableCollection<PersonModel> people;

        public ObservableCollection<PersonModel> People
        {
            get => people;
            set
            {
                people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public MainViewModel()
        {
            People = new ObservableCollection<PersonModel>();
        }

        public void SavePerson()
        {
            var person = new PersonModel { FirstName = FirstName, LastName = LastName };
            SQLiteDataAccess.SavePerson(person);
        }

        public void LoadPeople()
        {
            People = new ObservableCollection<PersonModel>(SQLiteDataAccess.GetPeople());

        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
