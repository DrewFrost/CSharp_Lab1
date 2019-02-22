using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CSharp1.Models;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;

namespace CSharp1.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        private string _age;
        private string _westernzodiac;
        private string _chinesezodiac;
        private bool _canExecute;
        private RelayCommand _ageCalc;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;


        public UserViewModel(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
            CanExecute = true;
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public string WesternZodiac
        {
            get { return _westernzodiac; }
            set { _westernzodiac = value; OnPropertyChanged(); }
        }

        public string ChineseZodiac
        {
            get { return _chinesezodiac; }
            set { _chinesezodiac = value; OnPropertyChanged(); }
        }

        public bool CanExecute
        {
            get { return _canExecute; }
            private set
            {
                _canExecute = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CountAge
        {
            get { return _ageCalc ?? (_ageCalc = new RelayCommand(AgeCalcImpl)); }
        }

        private async void AgeCalcImpl(object o)
        {
            _showLoaderAction.Invoke(true);
            CanExecute = false;
            await Task.Run((() =>
            {
                StationManager.CurrentUser = UserAdapter.CreateUser(_dateOfBirth);
                Thread.Sleep(2000);
            }));

            if (StationManager.CurrentUser == null)
                MessageBox.Show($"Don't lie to me with that {_dateOfBirth}");

            else
            {
                if (_dateOfBirth.DayOfYear == DateTime.Today.DayOfYear)
                    MessageBox.Show("Oh, guess who has birthday today!");

                Age = $"{StationManager.CurrentUser.Age}";
                WesternZodiac = StationManager.CurrentUser.WesternZodiac;
                ChineseZodiac = StationManager.CurrentUser.ChineseZodiac;
                _closeAction.Invoke();
            }

            CanExecute = true;

            _showLoaderAction.Invoke(false);
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }


}

