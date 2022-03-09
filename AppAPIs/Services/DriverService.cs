namespace AppAPIs.Services
{
    public class DriverService : IDriverService
    {
        private readonly DBContext _dbContext;

        public DriverService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Driver> Add(Driver driver)
        {
            await _dbContext.AddAsync(driver);
            _dbContext.SaveChanges();
            return driver;
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
            return await _dbContext.Drivers.ToListAsync();
        }

        public async Task<Driver> GetByID(int id)
        {
            return await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }

        public Driver Update(Driver driver)
        {
            _dbContext.Update(driver);
            _dbContext.SaveChanges();

            return driver;
        }
        public Driver Delete(Driver driver)
        {
            _dbContext.Remove(driver);
            _dbContext.SaveChanges();
            return driver;

        }
        public async Task<bool> IdExist(int id)
        {
            return await _dbContext.Drivers.AnyAsync(d => d.Id == id);
        }
    }
}
