namespace DAL.Migrations
{
    using DAL.EF_Code_First.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF_Code_First.AgroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF_Code_First.AgroContext context)
        {

            Random random = new Random();
            string[] districtList = new string[] {
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
                "Rajshahi",
                "Chanpur"

            };

            //this is for seeding district
            List<District> district = new List<District>();
            for (int i = 1; i < districtList.Length; i++)
            {
                district.Add(new District
                {
                    Id = i,
                    Name = districtList[i]
                });
            }
            context.District.AddOrUpdate(district.ToArray());

            //for users
            List<Users> users = new List<Users>();
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
                    District = districtList[random.Next(1, 22)],
                    Wallet = 5000
                });
            }
            context.Users.AddOrUpdate(users.ToArray());


            //for admin
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
                    Username = "adminname" + i,
                    Password = "adminpassword" + i,
                });
            }
            context.Admins.AddOrUpdate(admins.ToArray());

            //For gov official
            List<GovmentOfficial> GovmentOfficial = new List<GovmentOfficial>();
            for (int i = 1; i <= 15; i++)
            {
                GovmentOfficial.Add(new GovmentOfficial()
                {
                    Id = i,
                    Name = "Govment Name " + i,
                    Phone = "0182134" + random.Next(0000, 9999),
                    Email = "Govment" + i + "@gmail.com",
                    //Dob = DateTime.ParseExact(random.Next(1995,2023)+"-"+ "random.Next(1,12)" + "-"+ random.Next(1, 30) + "14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture),
                    Username = "govment" + i,
                    Password = "govment" + i,
                    District = districtList[random.Next(1, 22)]
                });
            }
            context.GovmentOfficial.AddOrUpdate(GovmentOfficial.ToArray());

            //for Lease Land
            List<LeaseLands> leaseLands = new List<LeaseLands>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(1995, 2023);
                if (i % 2 == 0)
                {
                    leaseLands.Add(new LeaseLands()
                    {
                        Id = i,
                        Address = Guid.NewGuid().ToString().Substring(0, 15),
                        District = districtList[random.Next(1, 22)],
                        Price = 3000,
                        OwnerId = random.Next(1, 15),
                        Landsize = random.Next(100, 1000),
                        Discription = Guid.NewGuid().ToString().Substring(0, 15),
                        Status = "Verified",
                        Publishtime = DateTime.Now,
                        GovmentId = 1,
                        Period = random.Next(0, 6)
                    });
                }
                else
                {
                    leaseLands.Add(new LeaseLands()
                    {
                        Id = i,
                        Address = Guid.NewGuid().ToString().Substring(0, 15),
                        District = districtList[random.Next(1, 22)],
                        Price = 3000,
                        OwnerId = random.Next(1, 15),
                        Landsize = random.Next(100, 1000),
                        Discription = Guid.NewGuid().ToString().Substring(0, 15),
                        Status = "Unverified",
                        Publishtime = DateTime.Now,
                        GovmentId = null,
                        Period = random.Next(0, 6)
                    });
                }
            }
            context.LeaseLands.AddOrUpdate(leaseLands.ToArray());

            string[] crops = new string[] {
                "Rice",
                "Corn",
                "Fruit",
                "Vegetables",
                "Oil Crops",
                "Wheat",
                "Potato"
            };

            //For Invest Lands
            List<InvestLands> investLands = new List<InvestLands>();
            for (int i = 1; i <= 20; i++)
            {
                var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(2023, 2025);
                if (i % 2 == 0)
                {
                    investLands.Add(new InvestLands()
                    {
                        Id = i,
                        Address = Guid.NewGuid().ToString().Substring(0, 15),
                        WhichCrops = crops[random.Next(1, 7)],
                        Moneyneed = 2000,
                        Estimatedprofit = random.Next(40000, 100000),
                        OwnerId = random.Next(1, 15),
                        Landsize = random.Next(100, 1000),
                        Publishtime = DateTime.Now,
                        Discription = Guid.NewGuid().ToString().Substring(0, 15),
                        Status = "Verified",
                        Totalinvestedammount = 0,
                        GovmentId = 1,
                        ExpectedCompleteTime = DateTime.Parse(date, new CultureInfo("en-US", true)),
                        District = districtList[random.Next(1, 22)]
                    });
                }
                else
                {
                    investLands.Add(new InvestLands()
                    {
                        Id = i,
                        Address = Guid.NewGuid().ToString().Substring(0, 15),
                        WhichCrops = crops[random.Next(1, 7)],
                        Moneyneed = 2000,
                        Estimatedprofit = random.Next(40000, 100000),
                        OwnerId = random.Next(1, 15),
                        Landsize = random.Next(100, 1000),
                        Publishtime = DateTime.Now,
                        Discription = Guid.NewGuid().ToString().Substring(0, 15),
                        Status = "Unverified",
                        Totalinvestedammount = 0,
                        GovmentId = null,
                        ExpectedCompleteTime = DateTime.Parse(date, new CultureInfo("en-US", true)),
                        District = districtList[random.Next(1, 22)]
                    });
                }
            }
            context.InvestLands.AddOrUpdate(investLands.ToArray());


            ////for confirm lease
            //List<ConfirmLease> confirmLeases = new List<ConfirmLease>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    confirmLeases.Add(new ConfirmLease()
            //    {
            //        Id = i,
            //        UserId = random.Next(1, 15),
            //        LandId = random.Next(1, 15),
            //        CreatedDate = DateTime.Now
            //    });
            //}
            //context.ConfirmLeases.AddOrUpdate(confirmLeases.ToArray());


            //for confirm invest
            //List<ConfirmInvestments> confirmInvestments = new List<ConfirmInvestments>();
            //for (int i = 1; i <= 10; i++)
            //{
            //    var date = random.Next(1, 12) + "/" + random.Next(1, 12) + "/" + random.Next(2023, 2025);
            //    confirmInvestments.Add(new ConfirmInvestments()
            //    {
            //        Id = i,
            //        UserId = random.Next(1, 15),
            //        LandId = random.Next(1, 15),
            //        InvestedAmmount = random.Next(500, 800),
            //        ReturnedAmmount = null,
            //        Status = "In funding",
            //        InvestTime = DateTime.Now
            //    });
            //}
            //context.ConfirmInvestments.AddOrUpdate(confirmInvestments.ToArray());


            List<Transaction> Transaction = new List<Transaction>();
            for (int i = 1; i <= 15; i++)
            {
                Transaction.Add(new Transaction()
                {
                    Id = i,
                    ReceiverId = i,
                    SenderId = i,
                    Ammount = 5000,
                    TransactionTime = DateTime.Now,
                    Type = "Deposit"
                });
            }
            context.Transaction.AddOrUpdate(Transaction.ToArray());
        }
    }
}
