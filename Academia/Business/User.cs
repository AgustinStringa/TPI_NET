using Entities;
namespace Business
{
    public class User
    {

        public void create(Entities.User newUser) {
            //validations and call to Data Layout
        }
        public void findOne(int id) { }
        public IEnumerable<Entities.User> findAll() { 
            return new List<Entities.User>();
        }
        public void update() { }
        public void delete(int id) { }
    }
}
