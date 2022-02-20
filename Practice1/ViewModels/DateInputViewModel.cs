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
        public string ZodiacSign { get => westernZodiacSign; set => westernZodiacSign = value; }
        public int Age { get => age; set => age = value; }
        #endregion
       
        private void chineezeZod(DateTime dt)
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
        private void zod(DateTime dt)
        {
            switch (dt.Month)
            {
                case 1:
                    if (dt.Day < 21)
                        ZodiacSign = "Capricorn";
                    else
                        ZodiacSign = "Aquarius";
                    break;

                case 2:
                    if (dt.Day < 20)
                        ZodiacSign = "Aquarius";
                    else
                        ZodiacSign = "Pisces";
                    break;

                case 3:
                    if (dt.Day < 21)
                        ZodiacSign = "Pisces";
                    else
                        ZodiacSign = "Aries";
                    break;

                case 4:
                    if (dt.Day < 21)
                        ZodiacSign = "Aries";
                    else
                        ZodiacSign = "Taurus";
                    break;

                case 5:
                    if (dt.Day < 22)
                        ZodiacSign = "Taurus";
                    else
                        ZodiacSign = "Gemini";
                    break;

                case 6:
                    if (dt.Day < 22)
                        ZodiacSign = "Gemini";
                    else
                        ZodiacSign = "Cancer";
                    break;

                case 7:
                    if (dt.Day < 23)
                        ZodiacSign = "Cancer";
                    else
                        ZodiacSign = "Leo";
                    break;

                case 8:
                    if (dt.Day < 22)
                        ZodiacSign = "Leo";
                    else
                        ZodiacSign = "Virgo";
                    break;

                case 9:
                    if (dt.Day < 24)
                        ZodiacSign = "Virgo";
                    else
                        ZodiacSign = "Libra";
                    break;

                case 10:
                    if (dt.Day < 24)
                        ZodiacSign = "Libra";
                    else
                        ZodiacSign = "Scorpio";
                    break;

                case 11:
                    if (dt.Day < 24)
                        ZodiacSign = "Scorpio";
                    else
                        ZodiacSign = "Sagittarius";
                    break;

                case 12:
                    if (dt.Day < 23)
                        ZodiacSign = "Sagittarius";
                    else
                        ZodiacSign = "Capricorn";
                    break;

            }
        }

        private void AgeOutput()
        {
            var date = dateInput;
            var currentDate = DateTime.Now;

            bool sameMonth = (currentDate.Month - date.DateTime.Month) == 0 ? true : false;
            bool sameDay = (currentDate.Day - date.DateTime.Day) == 0 ? true : false;

            //Розрахуйте вік користувача.
            //Виведіть вік користувача в TextBlock
            Age = ((currentDate.Month - date.DateTime.Month) < 1) ? currentDate.Year - date.DateTime.Year - 1 :
                (sameMonth ? ((currentDate.Day - date.DateTime.Day) < 1 ? (currentDate.Year - date.DateTime.Year - 1) :
                (currentDate.Year - date.DateTime.Year)) : (currentDate.Year - date.DateTime.Year));

            //Перевірте, чи вік користувача правильний. Наприклад,
            //якщо користувач ще не народився чи йому більше ніж 135 років, виведіть повідомлення про помилку.
            //(використайте клас MessageBox для відображення)
            if (Age < 0 || Age > 135)
            {
                MessageBox.Show("Birth date is wrong!");
            }

            //Якщо сьогодні день народження користувача, виведіть приємне повідомлення.
            if (sameMonth && sameDay)
            {
                MessageBox.Show($"Happy {Age}th birthday!");
            }

            chineezeZod(date.DateTime);
            zod(date.DateTime);
            OnPropertyChanged("Age");
            OnPropertyChanged("ChineseZodiacSign");
            OnPropertyChanged("ZodiacSign");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}