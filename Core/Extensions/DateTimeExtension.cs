using System;

namespace Core.Extensions
{
    public static class DateTimeExtension
    {
        public static int Age(this DateTime birthDate)
        {
            return Age(birthDate, DateTime.Today);
        }
        public static int Age(this DateTime birthDate,DateTime laterDate)
        {
            int age;
            age = laterDate.Year - birthDate.Year;

            if (age > 0)
            {
                age -= Convert.ToInt32(laterDate.Date < birthDate.Date.AddYears(age));
            }
            else
            {
                age = 0;
            }

            return age;
        }
    }
}
