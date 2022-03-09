using Microsoft.EntityFrameworkCore;

namespace AppAPIs.Services
{
    public class JourneyServices : IJourneyServices
    {
        private readonly DBContext _dbContext;

        public JourneyServices(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Journey> Add(Journey journey)
        {
            await _dbContext.AddAsync(journey);
            _dbContext.SaveChanges();
            return journey;
        }
        
        public async Task<IEnumerable<Journey>> GetAll()
        {
            return await _dbContext.Journeys.ToListAsync();

        }

        public async Task<Journey> GetByID(int id)
        {
            return await _dbContext.Journeys.FirstOrDefaultAsync(j => j.Id == id);
        }

        public Journey Update(Journey journey)
        {
            _dbContext.Update(journey);
            _dbContext.SaveChanges();

            return journey;
        }
        public Journey Delete(Journey journey)
        {
            _dbContext.Remove(journey);
            _dbContext.SaveChanges();
            return journey;
                
        }
        public async Task<bool> IdExist(int id)
        {
            return await _dbContext.Journeys.AnyAsync(j => j.Id == id);
        }

    }
}
