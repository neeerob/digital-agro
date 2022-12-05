namespace DAL.Migrations
{
    using DAL.EF_Code_First.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF_Code_First.AgroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF_Code_First.AgroContext context)
        {
            List<Users> users = new List<Users>();
            Random random = new Random();
            string[] district = new string[] {
                "Dhaka",
                "Faridpur",
                "Gazipur",
                "Gopalganj",
                "Jamalpur",
                "Kishoreganj",
                "Madaripur",
                "Manikganj",
                "Munshiganj",
                "Mymensingh",
                "Narayanganj",
                "Narsingdi",
                "Netrokona",
                "Rajbari",
                "Shariatpur",
                "Sherpur",
                "Tangail",
                "Bogra",
                "Joypurhat",
                "Naogaon",
                "Natore",
                "Nawabganj",
                "Pabna",
                "Rajshahi"

            };
            for (int i = 1; i <= 15; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(1995, 2023);
                users.Add(new Users()
                {
                    Id = i,
                    Name = "User Name " + i,
                    Phone = "0182134" + random.Next(0000, 9999),
                    Email = "user" + i + "@gmail.com",
                    Dob = DateTime.Parse(date, new CultureInfo("en-US", true)),
                    //Dob = DateTime.ParseExact(random.Next(1995,2023)+"-"+ "random.Next(1,12)" + "-"+ random.Next(1, 30) + "14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                    Username = "username" + i,
                    Password = "userpassword" + i,
                    Address = Guid.NewGuid().ToString().Substring(0, 15),
                    District = district[random.Next(1,22)],
                    Wallet = 5000
                }) ;
            }
            context.Users.AddOrUpdate(users.ToArray());

            List<Admins> admins = new List<Admins>();
            for (int i = 1; i <= 15; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(1995, 2023);
                admins.Add(new Admins()
                {
                    Id = i,
                    Name = "Admin Name " + i,
                    Phone = "0182134" + random.Next(0000, 9999),
                    Email = "admin" + i + "@gmail.com",
                    Dob = DateTime.Parse(date, new CultureInfo("en-US", true)),
                    //Dob = DateTime.ParseExact(random.Next(1995,2023)+"-"+ "random.Next(1,12)" + "-"+ random.Next(1, 30) + "14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                    Username = "Adminname" + i,
                    Password = "Adminpassword" + i,
                });
            }
            context.Admins.AddOrUpdate(admins.ToArray());

            List<LeaseLands> leaseLands = new List<LeaseLands>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(1995, 2023);
                leaseLands.Add(new LeaseLands()
                {
                    Id = i,
                    Address = Guid.NewGuid().ToString().Substring(0, 15),
                    District = district[random.Next(1, 22)],
                    Price = 3000,
                    OwnerId = random.Next(1, 15),
                    Landsize = random.Next(100, 1000),
                    Discription = Guid.NewGuid().ToString().Substring(0, 15),
                    Status = "Unvarified",
                    Publishtime = DateTime.Now
                }) ;
            }
            context.LeaseLands.AddOrUpdate(leaseLands.ToArray());

            string[] crops = new string[] {
                "Rice",
                "Corn",
                "Fruit",
                "Vegetables",
                "Oil Crops",
                "Wheat",
                "Potato" };
            List<InvestLands> investLands = new List<InvestLands>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(2023, 2025);
                investLands.Add(new InvestLands()
                {
                    Id = i,
                    Address = Guid.NewGuid().ToString().Substring(0, 15),
                    WhichCrops = crops[random.Next(1,7)],
                    Moneyneed = random.Next(1000, 3000),
                    Estimatedprofit = random.Next(4000, 10000),
                    OwnerId = random.Next(1, 15),
                    Landsize = random.Next(100, 1000),
                    Discription = Guid.NewGuid().ToString().Substring(0, 15),
                    Status = "Unvarified",
                    Publishtime = DateTime.Now,
                    Totalinvestedammount = 0,
                    ExpectedCompleteTime = DateTime.Parse(date, new CultureInfo("en-US", true)),
                    District = district[random.Next(1, 22)]
                });
            }
            context.InvestLands.AddOrUpdate(investLands.ToArray());

            List<ConfirmLease> confirmLeases = new List<ConfirmLease>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(2023, 2025);
                confirmLeases.Add(new ConfirmLease()
                {
                    Id = i,
                    UserId = random.Next(1, 15),
                    LandId = random.Next(1, 15),
                    PayedPrice = 3000
                }) ;
            }
            context.ConfirmLeases.AddOrUpdate(confirmLeases.ToArray());

            List<ConfirmInvestments> confirmInvestments = new List<ConfirmInvestments>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(2023, 2025);
                confirmInvestments.Add(new ConfirmInvestments()
                {
                    Id = i,
                    UserId = random.Next(1, 15),
                    LandId = random.Next(1, 15),
                    InvestedAmmount = random.Next(500, 800),
                    ReturnedAmmount = null,
                    Status = "In funding",
                    Publishtime = DateTime.Now
                });
            }
            context.ConfirmInvestments.AddOrUpdate(confirmInvestments.ToArray());
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
