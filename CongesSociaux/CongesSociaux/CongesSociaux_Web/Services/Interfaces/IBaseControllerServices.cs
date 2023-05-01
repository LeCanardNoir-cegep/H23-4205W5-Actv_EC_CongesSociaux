
namespace CongesSociaux_Web.Services.Interfaces
{
    public interface IBaseControllerServices<T,U> where T : class
    {
        Task<IEnumerable<U>?> Index();
        Task<T?> Details(int id);
        Task Create(U vm);
        Task<T> Update(T model);
        Task Delete(int id, bool confirmed);
        Task Delete(int id);
        Task<bool> IsExist(int id);
    }
}
