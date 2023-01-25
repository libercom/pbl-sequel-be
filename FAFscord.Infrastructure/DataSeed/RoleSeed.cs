using FAFscord.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Infrastructure.DataSeed
{
    public static class RoleSeed
    {
        public static void SeedChatRole(this ModelBuilder builder)
        {
            builder.Entity<ChatRole>().HasData(
                new ChatRole
                {
                    Id = new Guid("C5627232-B455-4D6C-9B6E-BA14B6589FD9"),
                    Role = "Admin"
                },
                new ChatRole
                {
                    Id = new Guid("FBAD6E22-61C9-4772-A379-5462FF42496E"),
                    Role = "User"
                }
            );
        }
    }
}
