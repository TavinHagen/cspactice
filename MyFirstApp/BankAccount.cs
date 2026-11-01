public class BankAccount
{
    private decimal _balance;
    public decimal Balance => _balance;
    private static int totalAccounts;
    private string _owner;
    public string Owner => _owner;

    public BankAccount(string owner, decimal balance)
    {
        _owner = owner;
        _balance = balance;
        totalAccounts++;
    }

    public BankAccount(string owner) : this(owner, 0)
    {

    }

    public bool Deposit(decimal amount) 
    {
        if (amount <= 0)
        {
            return false;
        }

        _balance += amount;

        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > _balance)
        {
            return false;
        }

        _balance -= amount;
        return true;
    }

    public override string ToString()
    {
        return $"{_owner}: {Balance:c}";
    }
}