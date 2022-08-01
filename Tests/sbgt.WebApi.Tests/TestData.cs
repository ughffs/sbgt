using sbgt.Repository.Context;
using sbgt.Repository.Entities;

namespace sbgt.WebApi.Tests;

public static class TestData
{
    public static DataContext SeedTestData(this DataContext context)
    {
        Items[0].Owner = Members[0];
        Items[1].Owner = Members[0];
        Items[2].Owner = Members[1];

        foreach (var member in Members)
        {
            context.Set<Member>().Add(member);
        }

        foreach (var item in Items)
        {
            context.Set<Item>().Add(item);
        }
        
        // Create some rental episodes
        RentEpisode episode = new RentEpisode()
        {
            Item = Items[0],
            Rentee = Members[2],
            StartDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow.AddDays(3)
        };

        context.Set<RentEpisode>().Add(episode);

        context.SaveChanges();

        return context;
    }

    public static IList<Member> Members { get; } = new List<Member>()
    {
        new()
        {
            Name = "Aaron Gregory",
            EmailAddress = "aaron.r.gregory@gmail.com",
            PrimaryContactNumber = "07919962743"
        },
        new()
        {
            Name = "Darren Thrower",
            EmailAddress = "darren.thrower@gmail.com",
            PrimaryContactNumber = "07919962847"
        },
        new()
        {
            Name = "Kieth Brumble",
            EmailAddress = "keith.brumble@gmail.com",
            PrimaryContactNumber = "07818826475"
        }
    };

    public static IList<Item> Items { get; } = new List<Item>()
    {
        new()
        {
            Name = "Power Drill"
        },
        new()
        {
            Name = "Angle Grinder"
        },
        new()
        {
            Name = "Saw"
        }
    };
}