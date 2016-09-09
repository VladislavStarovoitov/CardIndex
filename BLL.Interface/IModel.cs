using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
