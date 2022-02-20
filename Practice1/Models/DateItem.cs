using System;

namespace DateCheck.Models
{
    class DateItem
    {
        private DateTime _dateTime;

        public DateTime DateTime 
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }
    }
}
