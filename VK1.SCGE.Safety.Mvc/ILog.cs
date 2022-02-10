using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Mvc {
    public interface ILog {
        Task WriteAsync(string s);
    }
}
