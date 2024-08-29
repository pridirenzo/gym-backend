using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class Repository : IRepository
    {
        internal readonly GymContext _context;
        public Repository(GymContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0 ;
        }
    }
}
