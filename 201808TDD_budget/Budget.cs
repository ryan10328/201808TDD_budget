﻿using System;

namespace _201808TDD_budget
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime LastDay => DateTime.ParseExact(YearMonth + DaysInMonth, "yyyyMMdd", null);

        public int DaysInMonth => DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);

        public DateTime FirstDay => DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null);

        public decimal DailyAmount()
        {
            decimal dailyAmount = Amount / (decimal)DaysInMonth;
            return dailyAmount;
        }

        public decimal EffectiveAmount(Period period)
        {
            return DailyAmount() * period.OverlappingDays(CreatePeriod());
        }

        private Period CreatePeriod()
        {
            return new Period(this.FirstDay, this.LastDay);
        }
    }
}