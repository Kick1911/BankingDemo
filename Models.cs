using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intro;

public class BankingContext : DbContext {
    public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
}

public class User {
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Account {
    public int AccountId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public User User { get; set; }
}

public class Transaction {
    public int TransactionId { get; set; }
    public string Code { get; set; }
    public string Ref { get; set; }
    public double Amount { get; set; }
    public Account FromAccount { get; set; }

    public string ToAccount { get; set; }
}
