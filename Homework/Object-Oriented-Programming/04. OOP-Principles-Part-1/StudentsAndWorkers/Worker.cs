using System;

namespace StudentsAndWorkers
{
    class Worker : Human
    {
        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public Worker(string firstName,
            string lastName,
            decimal? weekSalary,
            int? workHoursPerDay,
            int? workDaysInAWeek = 5) : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
            WorkDaysInAWeek = workDaysInAWeek;
        }

        public decimal? WeekSalary { get; set; }
        public int? WorkHoursPerDay { get; set; }
        public int? WorkDaysInAWeek { get; set; }

        public decimal? MoneyPerHour()
        {
            return MoneyPerHour(this.WeekSalary, this.WorkHoursPerDay, this.WorkDaysInAWeek);
        }

        private decimal? MoneyPerHour(decimal? weekSalary,
            int? workHoursPerDay, int? workDaysInAWeek)
        {
            SimpleValidator.CheckNull(weekSalary, "Week salary");
            SimpleValidator.CheckNull(workHoursPerDay, "Work hours per day");
            SimpleValidator.CheckNull(workDaysInAWeek, "Work days in a week");

            return weekSalary / workDaysInAWeek / workHoursPerDay;
        }
    }
}