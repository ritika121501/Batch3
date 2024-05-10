namespace Batch3_RealTimeProject.DAL.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GenericRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void DeleteById(T obj)
        {
            _applicationDbContext.Set<T>().Remove(obj);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public T GetById(string id)
        {
            return _applicationDbContext.Set<T>().Find(id);
        }

        public void Update(T objModel)
        {
            _applicationDbContext.Entry(objModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public void Create(T objModel)
        {
            _applicationDbContext.Entry(objModel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _applicationDbContext.SaveChanges();
        }
    }
}
