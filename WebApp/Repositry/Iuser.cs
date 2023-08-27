using WebApp.Models;

namespace WebApp.Repositry
{
    public interface Iuser
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User Update(User user);
        public void Delete(int id);
        public User Add(User user);
    }
}
