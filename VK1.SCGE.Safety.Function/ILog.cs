using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VK1.SCGE.Safety.Function {
   public interface ILog {
        Task WriteAsync(string s);
    }
}
