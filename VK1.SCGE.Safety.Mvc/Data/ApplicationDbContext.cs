using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VK1.SCGE.Safety.Mvc.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}
