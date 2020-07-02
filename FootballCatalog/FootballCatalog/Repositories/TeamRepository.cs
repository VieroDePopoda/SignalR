using FootballCatalog.Models;
using FootballCatalog.Interfaces;

namespace FootballCatalog.Repositories
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context)
        {
        }
    }
}
