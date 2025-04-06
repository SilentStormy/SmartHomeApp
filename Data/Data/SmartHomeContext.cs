using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data.Data
{
    public class SmartHomeContext:DbContext
    {
        public SmartHomeContext(DbContextOptions<SmartHomeContext> options) : base(options) 
        
        { 
            
            
        }
        public DbSet<UserDTO> Users { get; set; }
    }
}
