using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Entities;
using ToyBox.Domain.Abstract;

namespace ToyBox.Domain.Concrete
{
    public class EFConditionRepository : IConditionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Condition> Condition
        {
            get { return context.Condition; }
        }
    }
}
