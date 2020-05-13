using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Entities;
using ToyBox.Domain.Abstract;

namespace ToyBox.Domain.Concrete
{
    class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Categorys
        {
            get { return context.Categories; }
        }
    }
}
