using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;
using VK1.SCGE.Safety.Services.Core;

namespace VK1.SCGE.Safety.Services {
    public class CardControlService : ServiceBase<CardControl> {
        private readonly App app;

        public CardControlService(App app) : base(app) {
            this.app = app;
            //
        }
      
    }
}
