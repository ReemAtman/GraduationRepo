namespace AppAPIs.Services
{
    public interface IJourneyServices
    {
        Task<IEnumerable<Journey>> GetAll();
        Task<Journey> GetByID(int id);
        Task<Journey> Add(Journey journey);
        Journey Update(Journey journey);
        Journey Delete(Journey journey);
        Task<bool> IdExist(int id);


    }
}
