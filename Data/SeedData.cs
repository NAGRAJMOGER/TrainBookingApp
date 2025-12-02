using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainBookingApp.Models;

namespace TrainBookingApp.Data;

/// <summary>
/// Seeds initial data into the database
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Initializes the database with seed data
    /// </summary>
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        // Ensure database is created
        await context.Database.EnsureCreatedAsync();

        // Check if data already exists
        if (context.Stations.Any())
        {
            return; // Database has been seeded
        }

        // Seed Stations
        var stations = new[]
        {
            new Station { Name = "Mumbai Central", Code = "MMCT", City = "Mumbai", State = "Maharashtra" },
            new Station { Name = "New Delhi", Code = "NDLS", City = "New Delhi", State = "Delhi" },
            new Station { Name = "Bangalore City", Code = "BNC", City = "Bangalore", State = "Karnataka" },
            new Station { Name = "Chennai Central", Code = "MAS", City = "Chennai", State = "Tamil Nadu" },
            new Station { Name = "Howrah Junction", Code = "HWH", City = "Kolkata", State = "West Bengal" },
            new Station { Name = "Pune Junction", Code = "PUNE", City = "Pune", State = "Maharashtra" },
            new Station { Name = "Hyderabad Deccan", Code = "HYB", City = "Hyderabad", State = "Telangana" },
            new Station { Name = "Ahmedabad Junction", Code = "ADI", City = "Ahmedabad", State = "Gujarat" },
            new Station { Name = "Jaipur Junction", Code = "JP", City = "Jaipur", State = "Rajasthan" },
            new Station { Name = "Lucknow", Code = "LKO", City = "Lucknow", State = "Uttar Pradesh" },
            new Station { Name = "Chandigarh", Code = "CDG", City = "Chandigarh", State = "Chandigarh" },
            new Station { Name = "Bhopal Junction", Code = "BPL", City = "Bhopal", State = "Madhya Pradesh" },
        };
        context.Stations.AddRange(stations);
        await context.SaveChangesAsync();

        // Seed Trains
        var trains = new[]
        {
            new Train { TrainNumber = "12951", TrainName = "Mumbai Rajdhani" },
            new Train { TrainNumber = "12301", TrainName = "Howrah Rajdhani" },
            new Train { TrainNumber = "12628", TrainName = "Karnataka Express" },
            new Train { TrainNumber = "12430", TrainName = "Lucknow AC SF" },
            new Train { TrainNumber = "12002", TrainName = "Bhopal Shatabdi" },
            new Train { TrainNumber = "12137", TrainName = "Punjab Mail" },
            new Train { TrainNumber = "12009", TrainName = "Shatabdi Express" },
            new Train { TrainNumber = "12423", TrainName = "Rajdhani Express" },
        };
        context.Trains.AddRange(trains);
        await context.SaveChangesAsync();

        // Seed Schedules with different classes
        var schedules = new List<Schedule>();
        var random = new Random(42);

        // Mumbai to Delhi - Multiple classes
        schedules.Add(CreateSchedule(trains[0].Id, stations[0].Id, stations[1].Id, 
            new TimeSpan(16, 30, 0), new TimeSpan(8, 35, 0), SeatClass.AC1Tier, 3500m, 18));
        schedules.Add(CreateSchedule(trains[0].Id, stations[0].Id, stations[1].Id, 
            new TimeSpan(16, 30, 0), new TimeSpan(8, 35, 0), SeatClass.AC2Tier, 2200m, 46));
        schedules.Add(CreateSchedule(trains[0].Id, stations[0].Id, stations[1].Id, 
            new TimeSpan(16, 30, 0), new TimeSpan(8, 35, 0), SeatClass.AC3Tier, 1400m, 64));

        // Delhi to Kolkata - Multiple classes
        schedules.Add(CreateSchedule(trains[1].Id, stations[1].Id, stations[4].Id, 
            new TimeSpan(17, 0, 0), new TimeSpan(9, 55, 0), SeatClass.AC1Tier, 3200m, 18));
        schedules.Add(CreateSchedule(trains[1].Id, stations[1].Id, stations[4].Id, 
            new TimeSpan(17, 0, 0), new TimeSpan(9, 55, 0), SeatClass.AC2Tier, 2000m, 46));
        schedules.Add(CreateSchedule(trains[1].Id, stations[1].Id, stations[4].Id, 
            new TimeSpan(17, 0, 0), new TimeSpan(9, 55, 0), SeatClass.AC3Tier, 1300m, 64));

        // Mumbai to Bangalore - Multiple classes
        schedules.Add(CreateSchedule(trains[2].Id, stations[0].Id, stations[2].Id, 
            new TimeSpan(20, 0, 0), new TimeSpan(7, 40, 0), SeatClass.Sleeper, 800m, 72));
        schedules.Add(CreateSchedule(trains[2].Id, stations[0].Id, stations[2].Id, 
            new TimeSpan(20, 0, 0), new TimeSpan(7, 40, 0), SeatClass.AC3Tier, 1500m, 64));
        schedules.Add(CreateSchedule(trains[2].Id, stations[0].Id, stations[2].Id, 
            new TimeSpan(20, 0, 0), new TimeSpan(7, 40, 0), SeatClass.AC2Tier, 2300m, 46));

        // Delhi to Lucknow
        schedules.Add(CreateSchedule(trains[3].Id, stations[1].Id, stations[9].Id, 
            new TimeSpan(22, 15, 0), new TimeSpan(6, 10, 0), SeatClass.AC3Tier, 900m, 64));
        schedules.Add(CreateSchedule(trains[3].Id, stations[1].Id, stations[9].Id, 
            new TimeSpan(22, 15, 0), new TimeSpan(6, 10, 0), SeatClass.AC2Tier, 1400m, 46));

        // Delhi to Bhopal
        schedules.Add(CreateSchedule(trains[4].Id, stations[1].Id, stations[11].Id, 
            new TimeSpan(6, 0, 0), new TimeSpan(13, 25, 0), SeatClass.ChairCar, 700m, 78));
        schedules.Add(CreateSchedule(trains[4].Id, stations[1].Id, stations[11].Id, 
            new TimeSpan(6, 0, 0), new TimeSpan(13, 25, 0), SeatClass.FirstClass, 1200m, 20));

        // Mumbai to Pune
        schedules.Add(CreateSchedule(trains[5].Id, stations[0].Id, stations[5].Id, 
            new TimeSpan(7, 10, 0), new TimeSpan(10, 35, 0), SeatClass.SecondSitting, 250m, 100));
        schedules.Add(CreateSchedule(trains[5].Id, stations[0].Id, stations[5].Id, 
            new TimeSpan(7, 10, 0), new TimeSpan(10, 35, 0), SeatClass.ChairCar, 450m, 78));

        // Chennai to Bangalore
        schedules.Add(CreateSchedule(trains[6].Id, stations[3].Id, stations[2].Id, 
            new TimeSpan(6, 0, 0), new TimeSpan(11, 15, 0), SeatClass.ChairCar, 550m, 78));
        schedules.Add(CreateSchedule(trains[6].Id, stations[3].Id, stations[2].Id, 
            new TimeSpan(6, 0, 0), new TimeSpan(11, 15, 0), SeatClass.FirstClass, 950m, 20));

        // Delhi to Jaipur
        schedules.Add(CreateSchedule(trains[7].Id, stations[1].Id, stations[8].Id, 
            new TimeSpan(15, 45, 0), new TimeSpan(20, 30, 0), SeatClass.AC3Tier, 600m, 64));
        schedules.Add(CreateSchedule(trains[7].Id, stations[1].Id, stations[8].Id, 
            new TimeSpan(15, 45, 0), new TimeSpan(20, 30, 0), SeatClass.AC2Tier, 950m, 46));

        context.Schedules.AddRange(schedules);
        await context.SaveChangesAsync();

        // Seed Seats for each schedule
        foreach (var schedule in schedules)
        {
            var seats = new List<Seat>();
            for (int i = 1; i <= schedule.TotalSeats; i++)
            {
                seats.Add(new Seat
                {
                    ScheduleId = schedule.Id,
                    SeatNumber = $"{GetSeatClass(schedule.SeatClass)}-{i}",
                    IsBooked = false
                });
            }
            context.Seats.AddRange(seats);
        }
        await context.SaveChangesAsync();
    }

    private static Schedule CreateSchedule(int trainId, int originId, int destId, 
        TimeSpan departure, TimeSpan arrival, SeatClass seatClass, decimal price, int totalSeats)
    {
        var duration = arrival > departure 
            ? arrival - departure 
            : TimeSpan.FromHours(24) - departure + arrival;

        return new Schedule
        {
            TrainId = trainId,
            OriginStationId = originId,
            DestinationStationId = destId,
            DepartureTime = departure,
            ArrivalTime = arrival,
            Duration = duration,
            SeatClass = seatClass,
            Price = price,
            TotalSeats = totalSeats
        };
    }

    private static string GetSeatClass(SeatClass seatClass)
    {
        return seatClass switch
        {
            SeatClass.Sleeper => "SL",
            SeatClass.AC3Tier => "3A",
            SeatClass.AC2Tier => "2A",
            SeatClass.AC1Tier => "1A",
            SeatClass.FirstClass => "FC",
            SeatClass.SecondSitting => "2S",
            SeatClass.ChairCar => "CC",
            _ => "GEN"
        };
    }
}
