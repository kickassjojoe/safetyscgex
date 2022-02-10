using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Services.Core {
    public interface IInvestigateService {
        Task<PartOne> AddPartOneAsync(PartOne item);
        Task<PartTwo> AddPartTwoAsync(PartTwo item);
    }
}
