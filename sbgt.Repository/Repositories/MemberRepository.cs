using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class MemberRepository : BaseRepository<Item>, IMemberRepository
{
    public MemberRepository(DataContext context)
        : base(context)
    {
    }
    
    public async Task<Member> GetMemberByGuid(
        Guid guid,
        CancellationToken cancellationToken)
    {
        var member = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(m => m.Id == guid, cancellationToken);
        
        return member;
    }

    public async Task<List<Member>> GetAllMembers(CancellationToken cancellationToken)
    {
        var members = await Context.Members.ToListAsync(cancellationToken);
        return members;
    }

    public IQueryable<Member> AsQueryableWithNavigationProperties =>
        Context.Members
            .Include(m => m.Items);

}