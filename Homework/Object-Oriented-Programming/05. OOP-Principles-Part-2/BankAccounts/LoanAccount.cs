using System;

namespace BankAccounts
{
    public class LoanAccount : Account, IDeposit
    {
        private const int IndividualPreferenceInMonths = 3;
        private const int CompanyPreferenceInMonths = 2;

        public override decimal CalculateInterest(int periodInMonths)
        {
            SimpleValidator.CheckNotPositive(periodInMonths, "Interest period");
            int prefs = GetPreferencePeriod();

            // no interest for the first months
            if (periodInMonths <= prefs)
            {
                return 0;
            }

            return base.CalculateInterest(periodInMonths - prefs);
        }

        public void Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        private int GetPreferencePeriod()
        {
            if (this.Owner.GetType() == typeof(Individual))
            {
                return IndividualPreferenceInMonths;
            }
            else if (this.Owner.GetType() == typeof(Company))
            {
                return CompanyPreferenceInMonths;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}