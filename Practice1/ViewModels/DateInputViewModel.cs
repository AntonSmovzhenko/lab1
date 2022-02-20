using DateCheck.Models;
using DateCheck.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DateCheck.ViewModels
{
    class DateInputViewModel : INotifyPropertyChanged
    {
        #region Fields
        private DateItem dateInput = new DateItem();
        private int age;
        private RelayCommand<object> _ageOutputCommand;
        private string chineseZodiacSign;
        private string westernZodiacSign;
        #endregion

        #region Properties
        public DateTime SelectedDate
        {
            get
            {
                return dateInput.DateTime;
            }
            set
            {
                dateInput.DateTime = value;
            }
        }

        public RelayCommand<object> AgeOutputCommand
        {
            get
            {
                return _ageOutputCommand ??= new RelayCommand<object>(_ => AgeOutput());
            }
        }

        public string ChineseZodiacSign { get => chineseZodiacSign; set => chineseZodiacSign = value; }
        public string WesternZodiacSign { get => westernZodiacSign; set => westernZodiacSign = value; }
        public int Age { get => age; set => age = value; }
        #endregion
        private void westernZod(DateTime dt)
        {
            switch (dt.Month)
            {
                case 1:
                    if (dt.Day < 21)
                        WesternZodiacSign = "Capricorn";
                    else
                        WesternZodiacSign = "Aquarius";
                    break;
                case 2:
                    if (dt.Day < 20)
                        WesternZodiacSign = "Aquarius";
                    else
                        WesternZodiacSign = "Pisces";
                    break;
                case 3:
                    if (dt.Day < 21)
                        WesternZodiacSign = "Pisces";
                    else
                        WesternZodiacSign = "Aries";
                    break;
                case 4:
                    if (dt.Day < 21)
                        WesternZodiacSign = "Aries";
                    else
                        WesternZodiacSign = "Taurus";
                    break;
                case 5:
                    if (dt.Day < 22)
                        WesternZodiacSign = "Taurus";
                    else
                        WesternZodiacSign = "Gemini";
                    break;
                case 6:
                    if (dt.Day < 22)
                        WesternZodiacSign = "Gemini";
                    else
                        WesternZodiacSign = "Cancer";
                    break;
                case 17:
                    if (dt.Day < 23)
                        WesternZodiacSign = "Cancer";
                    else
                        WesternZodiacSign = "Leo";
                    break;
                case 8:
                    if (dt.Day < 22)
                        WesternZodiacSign = "Leo";
                    else
                        WesternZodiacSign = "Virgo";
                    break;
                case 9:
                    if (dt.Day < 24)
                        WesternZodiacSign = "Virgo";
                    else
                        WesternZodiacSign = "Libra";
                    break;
                case 10:
                    if (dt.Day < 24)
                        WesternZodiacSign = "Libra";
                    else
                        WesternZodiacSign = "Scorpio";
                    break;
                case 11:
                    if (dt.Day < 24)
                        WesternZodiacSign = "Scorpio";
                    else
                        WesternZodiacSign = "Sagittarius";
                    break;
                case 12:
                    if (dt.Day < 23)
                        WesternZodiacSign = "Sagittarius";
                    else
                        WesternZodiacSign = "Capricorn";
                    break;
            }
        }
        private void chineseZod(DateTime dt)
        {
            switch ((dt.Year - 4) % 12)
            {
                case 0:
                    ChineseZodiacSign = "Rat";
                    break;
                case 1:
                    ChineseZodiacSign = "Ox";
                    break;
                case 2:
                    ChineseZodiacSign = "Tiger";
                    break;
                case 3:
                    ChineseZodiacSign = "Rabbit";
                    break;
                case 4:
                    ChineseZodiacSign = "Dragon";
                    break;
                case 5:
                    ChineseZodiacSign = "Snake";
                    break;
                case 6:
                    ChineseZodiacSign = "Horse";
                    break;
                case 7:
                    ChineseZodiacSign = "Goat";
                    break;
                case 8:
                    ChineseZodiacSign = "Monkey";
                    break;
                case 9:
                    ChineseZodiacSign = "Rooster";
                    break;
                case 10:
                    ChineseZodiacSign = "Dog";
                    break;
                case 11:
                    ChineseZodiacSign = "Pig";
                    break;
            }
        }
        private void AgeOutput()
        {
            var date = dateInput;
            var currentDate = DateTime.Now;

            bool sameMonth = (currentDate.Month - date.DateTime.Month) == 0 ? true : false;
            bool sameDay = (currentDate.Day - date.DateTime.Day) == 0 ? true : false;

            Age = ((currentDate.Month - date.DateTime.Month) < 1) ? currentDate.Year - date.DateTime.Year - 1 :
                (sameMonth ? ((currentDate.Day - date.DateTime.Day) < 1 ? (currentDate.Year - date.DateTime.Year - 1) : (currentDate.Year - date.DateTime.Year)) : (currentDate.Year - date.DateTime.Year));
            if (Age < 0 || Age > 135)
                throw new ArgumentException($"Birth date {date} is wrong!");
            if (sameMonth && sameDay)
                MessageBox.Show($"Happy {Age}th birthday!");
            chineseZod(date.DateTime);
            westernZod(date.DateTime);
            OnPropertyChanged("Age");
            OnPropertyChanged("ChineseZodiacSign");
            OnPropertyChanged("WesternZodiacSign");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}