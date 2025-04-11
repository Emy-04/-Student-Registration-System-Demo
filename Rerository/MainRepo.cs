using UniWebApp.Data;
using UniWebApp.Rerository.Base;

namespace UniWebApp.Rerository
{
    public class MainRepo<T> : IRepository<T> where T : class
    {
        public MainRepo(AppDbContext context) 
        {
            this.context = context;
        }

        protected AppDbContext context;
        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }
    }
}
