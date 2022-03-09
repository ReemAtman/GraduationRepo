namespace AppAPIs.Services
{
    public class CarTypeService : ICarTypeService
    {

        private readonly DBContext _dbContext;

        public CarTypeService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarType> Add(CarType cartype)
        {
            await _dbContext.AddAsync(cartype);
            _dbContext.SaveChanges();
            return cartype;
        }

        public async Task<IEnumerable<CarType>> GetAll()
        {
            return await _dbContext.CarTypes.ToListAsync();

        }

        public async Task<CarType> GetByID(int id)
        {
            return await _dbContext.CarTypes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public CarType Update(CarType cartype)
        {
            _dbContext.Update(cartype);
            _dbContext.SaveChanges();

            return cartype;
        }
        public CarType Delete(CarType cartype)
        {
            _dbContext.Remove(cartype);
            _dbContext.SaveChanges();
            return cartype;

        }
        public async Task<bool> IdExist(int id)
        {
            return await _dbContext.CarTypes.AnyAsync(c => c.Id == id);
        }
    }
}
