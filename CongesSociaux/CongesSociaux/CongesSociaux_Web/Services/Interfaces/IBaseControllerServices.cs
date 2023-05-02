
namespace CongesSociaux_Web.Services.Interfaces
{
    public interface IBaseControllerServices<T,U> where T : class
    {
        Task<IEnumerable<U>?> Index();
        Task<U?> Details(int id);
        Task Create(U vm);
        Task Update(U vm);
        Task Delete(int id, bool confirmed);
        Task<T> Delete(int id);
        Task<bool> IsExist(int id);
        Task<bool> EntityIsEmpty();
    }
}
