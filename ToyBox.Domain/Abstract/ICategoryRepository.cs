using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Entities;

namespace ToyBox.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categorys{ get; }
    }
}
