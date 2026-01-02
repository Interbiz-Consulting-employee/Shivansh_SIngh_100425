using System;
using System.Threading;

class BankAccount
{
    private int _balance = 0;
    private readonly object _lock = new object();

    public void Deposit(int amount)
    {
        bool lockTaken = false;
        Monitor.Enter(_lock, ref lockTaken);
        try
        {
            int temp = _balance;
            Thread.Sleep(100);
            _balance = temp + amount;

            Console.WriteLine(
                $"Thread {Thread.CurrentThread.ManagedThreadId} " +
                $"deposited {amount}, Balance = {_balance}");
        }
        finally
        {
            if (lockTaken)
                Monitor.Exit(_lock);
        }
    }

    public int GetBalance()
    {
        return _balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Thread t1 = new Thread(() => account.Deposit(100));
        Thread t2 = new Thread(() => account.Deposit(200));
        Thread t3 = new Thread(() => account.Deposit(300));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
}
