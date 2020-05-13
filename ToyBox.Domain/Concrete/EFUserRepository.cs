using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Abstract;
using ToyBox.Domain.Entities;


namespace ToyBox.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveChanges(User user)
        {
            User model = new User();
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;

            context.SaveChanges();
        }

   



    }
}
