using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Context;
using sbgt.Repository.Entities;
using sbgt.Repository.Repositories.Interfaces;

namespace sbgt.Repository.Repositories;

public class MemberRepository : BaseRepository<ItemEntity>, IMemberRepository
{
    public MemberRepository(DataContext context)
        : base(context)
    {
    }
    
    public async Task<MemberEntity> GetMemberByGuid(
        Guid guid,
        CancellationToken cancellationToken)
    {
        var member = await AsQueryableWithNavigationProperties
            .SingleOrDefaultAsync(m => m.Id == guid, cancellationToken);
        
        return member;
    }

    public async Task<List<MemberEntity>> GetAllMembers(CancellationToken cancellationToken)
    {
        var members = await Context.Members.ToListAsync(cancellationToken);
        return members;
    }

    public IQueryable<MemberEntity> AsQueryableWithNavigationProperties =>
        Context.Members
            .Include(m => m.Items);

}