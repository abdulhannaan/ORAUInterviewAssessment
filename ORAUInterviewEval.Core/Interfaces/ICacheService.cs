using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Core.Interfaces
{
    public interface ICacheService
    {
        Dictionary<int, string> GetPrograms();
    }
}
