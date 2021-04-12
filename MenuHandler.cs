using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BicycleRenting.Models;

namespace BicycleRenting
{
    public class MenuHandler
    {
        #region MenuDisplays

        // Denna metod visar upp main menyn
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("---- Bicycle Renting ----");
            Console.WriteLine("1. Create Reservation");
            Console.WriteLine("2. Add Information");
            Console.WriteLine("3. Get Information");
            Console.WriteLine("4. Update Information");
            Console.WriteLine("5. Delete Information");
            Console.WriteLine("6. Exit Shop");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    CreateReservation();
                    break;
                case "2":
                    AddInformation();
                    break;
                case "3":
                    GetInformation();
                    break;
                case "4":
                    UpdateInformation();
                    break;
                case "5":
                    DeleteInformation();
                    break;
                case "6":
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        }

        // en metod som visar upp menyn för att lägga till data i databasen.
        public static void AddInformation()
        {
            Console.Clear();
            Console.WriteLine("What do you want to add?");
            Console.WriteLine("1. Add customer.");
            Console.WriteLine("2. Add bicycle.");
            Console.WriteLine("3. Add brand.");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    AddBicycle();
                    break;
                case "3":
                    AddBicycleBrand();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }

        }

        // Hanterar menyn som visas upp när man vill hämta information från databasen.
        // hittills funkar bara val 1 och 2.
        public static void GetInformation()
        {
            Console.Clear();
            Console.WriteLine("What information do you want to see?");
            Console.WriteLine("1. All Customers.");
            Console.WriteLine("2. Specific Customer.");
            Console.WriteLine("3. All Bicycles. (Not yet implemented)");
            Console.WriteLine("4. All Brands. (Not yet implemented)");
            Console.WriteLine("5. All Reservations. (Not yet implemented)");
            Console.WriteLine("6. Get all bicycles without power");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    ShowAllCustomers();
                    break;
                case "2":
                    GetCustomer();
                    break;
                case "3":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "4":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "5":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "6":
                    GetAllBicyclesWithOutPower();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }

        }

        // Här visar vi upp menyn för att uppdatera information i databasen.
        // hittills funkar det bara att uppdatera Customer.
        public static void UpdateInformation()
        {
            Console.Clear();
            Console.WriteLine("What information do you want to update?");
            Console.WriteLine("1. Customer.");
            Console.WriteLine("2. Bicycles. (Not yet implemented)");
            Console.WriteLine("3. Brands. (Not yet implemented)");
            Console.WriteLine("4. Reservations. (Not yet implemented)");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    UpdateCustomer();
                    break;
                case "2":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "3":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "4":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        }

        // en meny för att ta bort data. hittils funkar det bara att ta bort från Customer.
        public static void DeleteInformation()
        {
            Console.Clear();
            Console.WriteLine("What information do you want to delete?");
            Console.WriteLine("1. A Customer.");
            Console.WriteLine("2. A Bicycle. (Not yet implemented)");
            Console.WriteLine("3. A Brand. (Not yet implemented)");
            Console.WriteLine("4. A Reservation. (Not yet implemented)");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    DeleteCustomer();
                    break;
                case "2":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "3":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                case "4":
                    Console.WriteLine("Not yet implemented.");
                    ReturnToMainMenu();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }
        } 

        // Visar upp menyn för att uppdatera Customer. Just nu kan man bara ändra telefonnummret.
        public static void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("1. Phonenumber.");

            var input = Console.ReadKey().KeyChar.ToString();
            switch (input)
            {
                case "1":
                    UpdatePhoneNumber();
                    break;
                default:
                    DisplayMainMenu();
                    break;
            }

        }

        // snabb metod för att återvända till mainmenyn.
        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            DisplayMainMenu();
        }

        #endregion

        // Här skapar vi våra customers som sparas i databasen.
        public static void AddCustomer()
        {
            Console.Clear();

            var newCustomer = new Customer();
            Console.WriteLine("First name:");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Date of birth: (YYYY-MM-DD)");
            newCustomer.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Phonenumber:");
            newCustomer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Email:");
            newCustomer.Email = Console.ReadLine();

            try
            {
                using (var dbContext = new BicycleDbContext()) 
                {
                    dbContext.Customers.Add(newCustomer);
                    dbContext.SaveChanges();
                }
                Console.WriteLine($"Added {newCustomer.FirstName} {newCustomer.LastName} successfully.");
                ReturnToMainMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the Customer.");
                throw;
            }
        }

        // Denna metod lägger till en bicycle till databasen.
        // Samt man lägger till en ny brand om brand tabellen är tom.
        public static void AddBicycle()
        {
            Console.Clear();

            var newBicycle = new Bicycle();
 
            Console.WriteLine("Power: (0 - 100)");
            newBicycle.Power = int.Parse(Console.ReadLine());

            using (var dbContext = new BicycleDbContext())
            {
                if (dbContext.Brands.Count() == 0)
                {
                    Console.WriteLine("There are no brands available lets make one!");
                    var newBrand = new Brand();
                    Console.WriteLine("Name of the brand:");
                    newBrand.BicycleBrand = Console.ReadLine();

                    dbContext.Brands.Add(newBrand);
                }
                else
                {
                    Console.WriteLine("What brand do you want:");
                    var allBrandsInDb = dbContext.Brands.ToList();
                    for (int i = 0; i < allBrandsInDb.Count; i++)
                    {
                        Console.WriteLine($"{i}. {allBrandsInDb[i].BicycleBrand}");
                    }

                    var input = Console.ReadLine();
                    var inputAsInt = int.Parse(input);
                    var selectedBrand = allBrandsInDb.ElementAt(inputAsInt);
                    newBicycle.Brand = selectedBrand;

                    dbContext.Bicycles.Add(newBicycle);
                }


                try
                {
                    dbContext.SaveChanges();

                    Console.WriteLine("Success!");
                    ReturnToMainMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong.");
                    throw;
                }
            }

        }

        // Här lägger vi till ett cykelmärke i vår Brand tabell i databasen.
        public static void AddBicycleBrand()
        {
            Console.Clear();

            var newBrand = new Brand();
            Console.WriteLine("Name of the brand:");
            newBrand.BicycleBrand = Console.ReadLine();

            try
            {
                using (var dbContext = new BicycleDbContext())
                {
                    dbContext.Brands.Add(newBrand);
                    dbContext.SaveChanges();
                }
                Console.WriteLine($"Added {newBrand.BicycleBrand} successfully!");
                ReturnToMainMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the Brand.");
                throw;
            }
        }

        // Här skapar vi en reservation, där användaren matar in när bokningen 
        // skall starta och sluta samt vem bokningen ska tillhöra.
        public static void CreateReservation()
        {
            Console.Clear();
            var newReservation = new Reservation();

            using (var dbContext = new BicycleDbContext())
            {
                if (dbContext.Customers.Count() == 0)
                {
                    Console.WriteLine("Go register first!");
                    return;
                }
                else
                {
                    Console.WriteLine("Thank you for making a reservation with us!");
                    Console.WriteLine("When do you want the reservation? (YYYY-MM-DD)");
                    newReservation.StartDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("When do you want the reservation to end? (YYYY-MM-DD)");
                    newReservation.EndDate = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Enter your first name.");
                    var allCustomersInDb = dbContext.Customers.ToList();
                    var inputName = Console.ReadLine();
                    newReservation.Customer = allCustomersInDb.Find(x => x.FirstName == inputName);
                }

                try
                {
                    dbContext.Reservations.Add(newReservation);
                    dbContext.SaveChanges();

                    Console.WriteLine("You successfully made a new reservation!");
                    ReturnToMainMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong with the reservation");
                    throw;
                }

            }

        }

        // en enkel metod som listar alla customers vi har sparat i databasen.
        public static void ShowAllCustomers()
        {
            List<Customer> customers;

            using (var dbContext = new BicycleDbContext())
            {
                customers = dbContext.Customers.ToList();
            }
            Console.Clear();
            foreach (var customer in customers)
            {
                Console.Write(customer.FirstName + " " 
                    + customer.LastName + " " 
                    + customer.DateOfBirth + " " 
                    + customer.PhoneNumber + " " 
                    + customer.Email);
                Console.WriteLine();
            }

            ReturnToMainMenu();
        }

        // Tar fram en specifik Customer genom att söka efter namnet som användaren anger.
        public static void GetCustomer()
        {
            List<Customer> customers;
            using (var dbContext = new BicycleDbContext())
            {
                customers = dbContext.Customers.ToList();
            }
            Console.Clear();
            Console.WriteLine("First name of customer:");
            var inputName = Console.ReadLine();

            foreach (var customer in customers)
            {
                if (inputName == customer.FirstName)
                {
                    Console.Write(customer.FirstName + " ");
                    Console.Write(customer.LastName);
                    Console.WriteLine();
                    Console.WriteLine(customer.DateOfBirth);
                    Console.WriteLine(customer.PhoneNumber);
                    Console.WriteLine(customer.Email);
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }

            ReturnToMainMenu();
        }

        // Här matar användaren in ett namn som vi söker efter i databasen, och sedan bytar telefonnummret på den customern.
        public static void UpdatePhoneNumber()
        {
            List<Customer> customers;
            using (var dbContext = new BicycleDbContext())
            {
                customers = dbContext.Customers.ToList();

                Console.Clear();
                Console.WriteLine("First name of the customer you want to change:");
                var inputName = Console.ReadLine();

                foreach (var customer in customers)
                {
                    if (inputName == customer.FirstName)
                    {
                        Console.WriteLine($"{customer.FirstName} has phonenumber {customer.PhoneNumber}");
                        Console.WriteLine("New phonenumber: ");
                        var newPhoneNumber = Console.ReadLine();
                        customer.PhoneNumber = newPhoneNumber;
                        dbContext.Customers.Update(customer);

                        dbContext.SaveChanges();
                        Console.WriteLine("You successfully updated the phonenumber!");
                        ReturnToMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Customer not found.");
                        ReturnToMainMenu();
                    }
                }             
            }
        }

        // Här tar vi bort 1 customer genom att användaren matar in ett namn som vi söker 
        // efter och sedan frågar användaren om hen verkligen vill ta bort denna customer.
        public static void DeleteCustomer()
        {
            List<Customer> customers;
            using (var dbContext = new BicycleDbContext())
            {
                customers = dbContext.Customers.ToList();

                Console.Clear();
                Console.WriteLine("First name of the customer you want to delete:");
                var inputName = Console.ReadLine();

                foreach (var customer in customers)
                {
                    if (inputName == customer.FirstName)
                    {
                        Console.WriteLine($" Delete customer {customer.FirstName} {customer.LastName}?");
                        Console.WriteLine("Y/N?");
                        var input = Console.ReadLine();
                        Console.WriteLine($" Delete customer {customer.FirstName} {customer.LastName} reservations also?");
                        Console.WriteLine("Y/N?");
                        var deleteReservaionInput = Console.ReadLine();
                        if (input == "Y")
                        {
                            dbContext.Customers.Remove(customer);

                            dbContext.SaveChanges();
                            Console.WriteLine("You successfully deleted the customer!");
                            ReturnToMainMenu();
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong.");
                            ReturnToMainMenu();
                        }
 
                    }
                    else
                    {
                        Console.WriteLine("Customer not found.");
                        ReturnToMainMenu();
                    }
                }
                
            }
        }

        // Denna metod tar fram alla bicycles som har 0 i power.
        public static void GetAllBicyclesWithOutPower()
        {
            using (var dbContext = new BicycleDbContext())
            {
                Console.Clear();
                var bicyclesOutOfPower = dbContext.Bicycles.Where(b => b.Power == 0).ToList();

                foreach (var bicycle in bicyclesOutOfPower)
                {
                    Console.WriteLine($" ID: {bicycle.BicycleId} Power: {bicycle.Power}");
                }

                ReturnToMainMenu();
            }
        }
    }
}
