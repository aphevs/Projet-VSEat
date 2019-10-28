
using DataTransferObject;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using BusinessLayer;

namespace ConsoleApp
{
    class Program
    {
        
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            var restaurantsDBManager = new RestaurantManager(Configuration);

            Console.WriteLine("--Get all restaurants--");
            var restaurants = restaurantsDBManager.GetRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"IdRestaurant:{restaurant.IdRestaurant} created_at: {restaurant.created_at} IdCity: {restaurant.IdCity}name: {restaurant.name}");

            }


            var citiesDBManager = new CityManager(Configuration);

            //Get a city
            Console.WriteLine("--Get a city--");
            var city1 = citiesDBManager.GetCity(1);
            Console.WriteLine(city1.name);

            /*

            var customersDBManager = new CustomerManager(Configuration);

            var customers = customersDBManager.GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }

            //Get on customer
            Console.WriteLine("--NEW CUSTOMER--");
            var customer2 = customersDBManager.GetCustomer(2);
            Console.WriteLine(customer2.name);

            //Add new hotel
            Console.WriteLine("--Add CUSTOMER--");
            var newCustomer = customersDBManager.AddCustomer(new Customer {name = "Alex Piguet", created_at = new DateTime(2019, 10, 28), streetname = "Chemin des érables 29", idCity = 1 });
            Console.WriteLine($"ID: {newCustomer.idCustomer} Name: {newCustomer.name}");
            customers = customersDBManager.GetCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID:{customer.idCustomer} Name: {customer.name}") ;
                
            }

            

            //Update hotel
            Console.WriteLine("--Update HOTEL--");
            newHotel.Name = "Le Rhône";
            hotelsDBManager.UpdateHotel(newHotel);
            hotels = hotelsDBManager.GetHotels();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"ID:{hotel.IdHotel} Name: {hotel.Name}");
            }


            //Delete hotel
            
            Console.WriteLine("--Delete HOTEL--");
            hotelsDBManager.DeleteHotel(9);
            hotels = hotelsDBManager.GetHotels();
            foreach (var hotel in hotels)
            {
                Console.WriteLine($"ID:{hotel.IdHotel} Name: {hotel.Name}");
            }


            
            static void DisplayHotels(HotelManager hotelsDB)
            {
                var hotels = hotelsDB.GetHotel();
                foreach(var hotel in hotels)
                {
                    Console.WriteLine(hotel.Name);

                }

            }
            */


        }
    }
}
