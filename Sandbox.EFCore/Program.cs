// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;

int orangeId = 0;
using (var ctx = new AppDbContext())
{
    var orange = new Fruit {Name = "Orange"};
    var apple = new Fruit {Name = "Apple"};

    ctx.Fruits.Add(orange);
    orangeId = ctx.Entry(orange).Property<int>("Id").CurrentValue;
    ctx.Fruits.Add(apple);
    
    ctx.SaveChanges();
}

using (var ctx = new AppDbContext())
{
    var address = new Address {PostCode = "Moon"};
    ctx.Entry(address).Property<int>("FruitId").CurrentValue = orangeId;
    
    ctx.Addresses.Add(address);
    
    ctx.SaveChanges();
}

using (var ctx = new AppDbContext())
{
    var fruits = ctx.Fruits
        .Include(x => x.Address)
        .Select(x => new FruitVm
        {
            Id = EF.Property<int>(x, "Id"),
            Name = x.Name,
            Weight = x.Weight,
            PostCode = x.Address.PostCode
        })
        .ToList();

    var addresses = ctx.Addresses.ToList();
}

Console.ReadLine();

public class AppDbContext : DbContext
{
    public DbSet<Fruit> Fruits { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fruit>().Property<int>("Id");
        modelBuilder.Entity<Address>().Property<int>("FruitId");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Database");
    }
}

public class Fruit
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public int Id { get; set; }
    public string PostCode { get; set; }
}

public class FruitVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Weight { get; set; }
    public string PostCode { get; set; }
}