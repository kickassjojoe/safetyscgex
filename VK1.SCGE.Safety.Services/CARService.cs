using System;
using System.Collections.Generic;
using System.Text;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
   public class CARService : ServiceBase<CorrectiveActionRequest> {
        public CARService(App app):base(app) {
            //
        }
    }
}
