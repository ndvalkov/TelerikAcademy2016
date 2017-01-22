using System;

namespace BankAccounts
{
    public class MortgageAccount : Account, IDeposit
    {
        private const int IndividualPreferenceInMonths = 6;
        private const int CompanyPreferenceInMonths = 12;
        private const double CompanyInterestDiscount = 0.5;

        public void Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public override decimal CalculateInterest(int periodInMonths)
        {
            SimpleValidator.CheckNotPositive(periodInMonths, "Interest period");

            if (this.Owner.GetType() == typeof(Individual))
            {
                return CalculateInterestForIndividuals(periodInMonths);
            }
            else if (this.Owner.GetType() == typeof(Company))
            {
                return CalculateInterestForCompanies(periodInMonths);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private decimal CalculateInterestForIndividuals(int periodInMonths)
        {
            if (periodInMonths <= IndividualPreferenceInMonths)
            {
                return 0;
            }

            return base.CalculateInterest(periodInMonths);
        }

        private decimal CalculateInterestForCompanies(int periodInMonths)
        {
            if (periodInMonths <= CompanyPreferenceInMonths)
            {
                return base.CalculateInterest(periodInMonths) / 2M;
            }

            return base.CalculateInterest(CompanyPreferenceInMonths) *
                   (decimal) CompanyInterestDiscount +
                   base.CalculateInterest(periodInMonths - CompanyPreferenceInMonths);
        }
    }
}