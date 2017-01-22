namespace BankAccounts
{
    public abstract class Account
    {
        public ICustomer Owner { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public virtual decimal CalculateInterest(int periodInMonths)
        {
            return periodInMonths * this.InterestRate;
        }
    }
}