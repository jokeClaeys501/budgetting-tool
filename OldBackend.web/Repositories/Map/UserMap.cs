using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pencil42App.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Repositories.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Suggestions).WithOne().HasForeignKey(s => s.UserId);
            builder.HasMany(u => u.Weeks).WithOne().HasForeignKey(w => w.UserId);
            
        }

    }
}
