namespace BankAccounts
{
    public class DepositAccount : Account, IDeposit, IWithdraw
    {
        public override decimal CalculateInterest(int periodInMonths)
        {
            SimpleValidator.CheckNotPositive(periodInMonths, "Interest period");

            if (this.Balance > 0M && this.Balance < 1000M)
            {
                return 0;
            }

            return base.CalculateInterest(periodInMonths);
        }

        public void Deposit(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public decimal Withdraw()
        {
            throw new System.NotImplementedException();
        }
    }
}