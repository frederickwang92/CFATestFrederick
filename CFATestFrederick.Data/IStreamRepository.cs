using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFATestFrederick.Data
{
    public interface IStreamRepository<T>
    {
        T GetByIndex(int inputIndex);
    }
}
