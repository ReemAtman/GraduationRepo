namespace AppAPIs.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext _dbContext;

        public UserService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Add(User user)
        {
            await _dbContext.AddAsync(user);
            _dbContext.SaveChanges();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {

            var users = await _dbContext.Users.OrderBy(g => g.FirstName).ToListAsync();
            return users;
        }

        public async Task<User> GetByID(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
        public async Task<bool> IdExist(int id)
        {
            return await _dbContext.Users.AnyAsync(u => u.Id == id);
        }
        public User Update(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
        public User Delete(User user)
        {
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
