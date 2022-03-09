namespace AppAPIs.Services
{
    public interface ICarTypeService
    {
        Task<IEnumerable<CarType>> GetAll();
        Task<CarType> GetByID(int id);
        Task<CarType> Add(CarType cartype);
        CarType Update(CarType cartype);
        CarType Delete(CarType cartype);
        Task<bool> IdExist(int id);
    }
}
