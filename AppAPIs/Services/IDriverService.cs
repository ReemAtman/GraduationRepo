namespace AppAPIs.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAll();
        Task<Driver> GetByID(int id);
        Task<Driver> Add(Driver driver);
        Driver Update(Driver driver);
        Driver Delete(Driver driver);
        Task<bool> IdExist(int id);
    }
}
