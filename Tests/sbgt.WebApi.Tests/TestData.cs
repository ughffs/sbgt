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

        context.Database.EnsureCreated();
        
        foreach (var member in Members)
        {
            context.Set<MemberEntity>().Add(member);
        }

        foreach (var item in Items)
        {
            context.Set<ItemEntity>().Add(item);
        }
        
        // Create some rental episodes
        RentEpisodeEntity episodeEntity = new RentEpisodeEntity()
        {
            Item = Items[0],
            Rentee = Members[2],
            StartDateTime = DateTime.UtcNow,
            EndDateTime = DateTime.UtcNow.AddDays(3)
        };

        context.Set<RentEpisodeEntity>().Add(episodeEntity);

        context.SaveChanges();

        return context;
    }

    public static IList<MemberEntity> Members { get; } = new List<MemberEntity>()
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

    public static IList<ItemEntity> Items { get; } = new List<ItemEntity>()
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