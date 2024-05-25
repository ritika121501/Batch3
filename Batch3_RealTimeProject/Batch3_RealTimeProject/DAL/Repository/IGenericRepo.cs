using Batch3_RealTimeProject.Models;
using System.Linq.Expressions;

namespace Batch3_RealTimeProject.DAL.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T objModel);
        void DeleteById(T obj);
        void Create(T objModel);
        T GetById(string id);
        List<Product> GetByIdForList();
        ShoppingCart GetByIdProductDetails(int id);
        T Get(Expression<Func<T, bool>> filter = null, string? includeparams = null, bool tracking = false);
    }
}
