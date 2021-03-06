﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Poland
    /// </summary>
    public class PolandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// PolandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public PolandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.PL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "Nowy Rok", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Święto Trzech Króli", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday, "Wielkanoc", "Easter Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Drugi Dzień Wielkanocy", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Święto Pracy", "May Day", countryCode));
            items.Add(new PublicHoliday(year, 5, 3, "Święto Narodowe Trzeciego Maja", "Constitution Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Zielone Świątki", "Pentecost Sunday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(60), "Boże Ciało", "Corpus Christi", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Wniebowzięcie Najświętszej Maryi Panny", "Assumption Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 1, "Wszystkich Świętych", "All Saints' Day", countryCode));
            items.Add(new PublicHoliday(year, 11, 11, "Narodowe Święto Niepodległości", "Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Boże Narodzenie", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "Drugi Dzień Bożego Narodzenia", "St. Stephen's Day", countryCode));

            if (year == 2018)
            {
                //100th anniversary
                items.Add(new PublicHoliday(year, 11, 12, "Narodowe Święto Niepodległości", "Independence Day", countryCode));
            }

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Poland"
            };
        }
    }
}
