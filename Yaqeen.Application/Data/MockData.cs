using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Domain.Entities;
using Yaqeen.Application.Data;

namespace Yaqeen.Application.Data
{
    public class MockData
    {
        public static List<Citizen> Citizens = new List<Citizen>
        {
          new Citizen{
            NationalId = "1234567890",
            DateOfBirth = new DateOnly(2003, 3, 3),
            FullName = "Abdulmajeed Mohammed Alhasani",
            Gender = "Male", 
            Nationality = "Saudi"} ,

           new Citizen{
            NationalId = "1028365298",
            DateOfBirth = new DateOnly(1990, 11, 15),
            FullName = "Alhasan Mustafa Alharbi",
            Gender = "Male",
            Nationality= "Saudi" } ,

            new Citizen{
            NationalId = "302456789123",
            DateOfBirth = new DateOnly(2005, 2, 28),
            FullName = "Hamad Ahmed Al Sabah",
            Gender = "Male",
            Nationality= "Kuwaiti"}

        };


        public static List<Vehicle> Vehicles = new List<Vehicle>
        {
             new Vehicle{
                SequenceNumber = 1,
                PlateNumber = "1303",
                PlateLetters = "MJD",
                Make = "Toyota",
                Model = "Crown Sedan",
                ModelYear = 2023,
                Color = "Black",
                ChassisNumber = "XYZ1234567890",
                OwnerNationalId = "1234567890"
              },
            new Vehicle{
                SequenceNumber = 2,
                PlateNumber = "5678",
                PlateLetters = "DEF",
                Make = "Haval",
                Model = "V7",
                ModelYear = 2019,
                Color = "Blue",
                ChassisNumber = "XYZ0987654321",
                OwnerNationalId = "1028365298"
            },
            new Vehicle{
                SequenceNumber = 3,
                PlateNumber = "9012",
                PlateLetters = "AAI",
                Make = "Ford",
                Model = "Mustang",
                ModelYear = 2020,
                Color = "Black",
                ChassisNumber = "XYZ5678901234",
                OwnerNationalId = "302456789123"
            }
        };
    }

}
