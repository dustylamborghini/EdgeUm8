using Remote_db.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
namespace Remote_db.Repositories
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context) {
            base.Seed(context);
            SeedHouses(context);
        }

        public static void SeedHouses(ApplicationDbContext context) {
            House Nova = new House { HouseName = "Nova", Opens = new TimeSpan(06, 00, 00), Closes = new TimeSpan(23, 00, 00) };            
            House Lang = new House { HouseName = "Långhuset", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Teknik = new House { HouseName = "Teknikhuset", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Gymnastik = new House { HouseName = "Gymnastikhuset", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Forum = new House { HouseName = "Forumhuset", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Prisma = new House { HouseName = "Prismahuset", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Bilbergska = new House { HouseName = "Bilbergska", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            House Test = new House { HouseName = "Test", Opens = new TimeSpan(00, 00, 00), Closes = new TimeSpan(23, 59, 59) };
            context.Houses.AddRange(new[] {Nova, Lang, Teknik, Gymnastik, Forum, Prisma, Bilbergska, Test });
            context.SaveChanges();

            HouseRoom N2037 = new HouseRoom { Id = "N2037", HouseId = Nova.Id, Projector = true, WhiteBoard = true };
            HouseRoom L111 = new HouseRoom { Id = "L1112", HouseId = Lang.Id, Projector = true, WhiteBoard = true };
            HouseRoom T133 = new HouseRoom { Id = "T133", HouseId = Teknik.Id, Projector = true, WhiteBoard = true };
            HouseRoom G108 = new HouseRoom { Id = "G108", HouseId = Gymnastik.Id, Projector = false, WhiteBoard = true };
            HouseRoom F138 = new HouseRoom { Id = "F138", HouseId = Forum.Id, Projector = true, WhiteBoard = true };
            HouseRoom P104 = new HouseRoom { Id = "P104", HouseId = Prisma.Id, Projector = false, WhiteBoard = true };
            HouseRoom B187 = new HouseRoom { Id = "B187", HouseId = Bilbergska.Id, Projector = false, WhiteBoard = false };
            context.Rooms.AddRange(new[] { N2037, L111, T133, G108, F138, P104, B187 });
            context.SaveChanges();

            AvailableTimes Time1 = new AvailableTimes { RoomId = N2037.Id, From = new TimeSpan(09, 00, 00), To = new TimeSpan(10,00,00) };
            AvailableTimes Time2 = new AvailableTimes { RoomId = L111.Id, From = new TimeSpan(09,00,00) , To = new TimeSpan(10,00,00) };
            AvailableTimes Time3 = new AvailableTimes { RoomId = T133.Id, From = new TimeSpan(09,00,00) , To = new TimeSpan(10,00,00) };
            AvailableTimes Time4 = new AvailableTimes { RoomId = G108.Id, From = new TimeSpan(09, 00, 00), To = new TimeSpan(10, 00, 00) };
            AvailableTimes Time5 = new AvailableTimes { RoomId = F138.Id, From = new TimeSpan(09, 00, 00), To = new TimeSpan(10, 00, 00) };
            AvailableTimes Time6 = new AvailableTimes { RoomId = P104.Id, From = new TimeSpan(09, 00, 00), To = new TimeSpan(10, 00, 00) };
            AvailableTimes Time7 = new AvailableTimes { RoomId = B187.Id, From = new TimeSpan(09, 00, 00), To = new TimeSpan(10, 00, 00) };
            context.FreeIntervals.AddRange(new[] { Time1, Time2, Time3, Time4, Time5, Time6, Time7 });
            context.SaveChanges();            
        }
    }
}
