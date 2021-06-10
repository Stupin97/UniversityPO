namespace UniversityPO
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Helpers
    {
        public static string GetDateTime(DateTime? date)
        {
            string pattern = "MM-dd-yy";

            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            return "Вход выполнен в: " + date.Value.ToString(pattern, CultureInfo.CreateSpecificCulture("ru-RU"));
        }
    }
}
