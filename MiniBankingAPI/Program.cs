var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// testnode (without db)
var accounts = new List<BankAccount>
{
    new(1, "Assel", 200m),
    new(2, "Alex", 100m)
};

// call all nodes
app.MapGet("/accounts", () => accounts);

// sum balance of a specific account
app.MapGet("/accounts/{id}", (int id) =>
{
    var account = accounts.FirstOrDefault(a => a.Id == id);

    return account is null
        ? Results.NotFound()
        : Results.Ok(account);
});

app.Run();

record BankAccount(int Id, string Owner, decimal Balance);