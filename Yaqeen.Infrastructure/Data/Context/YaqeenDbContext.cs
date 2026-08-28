using Microsoft.EntityFrameworkCore;
using Yaqeen.Domain.Entities;

namespace Yaqeen.Infrastructure.Data.Context;

public class YaqeenDbContext : DbContext
{
    public YaqeenDbContext(DbContextOptions<YaqeenDbContext> options)
        : base(options)
    {
    }

    public DbSet<Citizen> Citizens { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Make> Makes { get; set; }

    public DbSet<Model> Models { get; set; }

    public DbSet<Address> Addresses { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Model>().HasOne(x => x.Make).WithMany(x => x.Models).HasForeignKey(x => x.MakeId);

        modelBuilder.Entity<Vehicle>().HasOne(x => x.Make).WithMany(x => x.Vehicles).HasForeignKey(x => x.MakeId);

modelBuilder.Entity<Vehicle>().HasOne(x => x.Model).WithMany(x => x.Vehicles).HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.NoAction);
   
        
        modelBuilder.Entity<Address>().HasOne(x => x.Citizen).WithMany(x => x.Addresses).HasForeignKey(x => x.CitizenId).OnDelete(DeleteBehavior.Cascade);



        //EF Core Seed Data.

        modelBuilder.Entity<Citizen>().HasData(

            new Citizen
            {
                NationalId = "1234567890",
                DateOfBirth = new DateOnly(2003, 3, 3),
                FullName = "Abdulmajeed Mohammed Alhasani",
                Gender = "Male",
                Nationality = "Saudi"
            },
            new Citizen
            {
                NationalId = "1028339274",
                DateOfBirth = new DateOnly(1990, 11, 15),
                FullName = "Alhasan Mustafa Alharbi",
                Gender = "Male",
                Nationality = "Saudi"
            },
            new Citizen
            {
                NationalId = "1920009789",
                DateOfBirth = new DateOnly(2005, 2, 28),
                FullName = "Hamad Ahmed Al Sabah",
                Gender = "Male",
                Nationality = "Saudi"
            }
        );


        //EF Core Seed Data.

        modelBuilder.Entity<Address>().HasData(
    new Address
    {
        Id = 1,
        AddressLine = "Riyadh",
        CitizenId = "1234567890"
    },
    new Address
    {
        Id = 2,
        AddressLine = "Jeddah",
        CitizenId = "1028339274"
    },
    new Address
    {
        Id = 3,
        AddressLine = "Abha",
        CitizenId = "1920009789"
    }
);



        //EF Core Seed Data.

        modelBuilder.Entity<Make>().HasData(
        new Make { Id = 1, Name = "Toyota" },
        new Make { Id = 2, Name = "Haval" },
        new Make { Id = 3, Name = "Ford" }
        );


        modelBuilder.Entity<Model>().HasData(
            new Model { Id = 1, Name = "Crown Sedan", MakeId = 1 },
            new Model { Id = 2, Name = "V7", MakeId = 2 },
            new Model { Id = 3, Name = "Mustang", MakeId = 3 }
        );

       
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle
            {
                SequenceNumber = 1,
                PlateNumber = "1303",
                PlateLetters = "MJD",
                MakeId = 1,
                ModelId = 1,
                ModelYear = 2023,
                Color = "Black",
                ChassisNumber = "XYZ1234567890",
                OwnerNationalId = "1234567890"
            },
            new Vehicle
            {
                SequenceNumber = 2,
                PlateNumber = "5678",
                PlateLetters = "DEF",
                MakeId = 2,
                ModelId = 2,
                ModelYear = 2019,
                Color = "Blue",
                ChassisNumber = "XYZ0987654321",
                OwnerNationalId = "1028339274"
            },
            new Vehicle
            {
                SequenceNumber = 3,
                PlateNumber = "9012",
                PlateLetters = "AAI",
                MakeId = 3,
                ModelId = 3,
                ModelYear = 2020,
                Color = "Black",
                ChassisNumber = "XYZ5678901234",
                OwnerNationalId = "1920009789"
            }
        );
    }
}