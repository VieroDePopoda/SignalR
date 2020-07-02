using FootballCatalog.Models;
using FootballCatalog.Interfaces;

namespace FootballCatalog.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
