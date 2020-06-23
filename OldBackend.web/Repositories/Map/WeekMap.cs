using Microsoft.EntityFrameworkCore;
using Pencil42App.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pencil42App.Web.Repositories.Map
{
    public class WeekMap : IEntityTypeConfiguration<Week>
    {
        public void Configure(EntityTypeBuilder<Week> builder)
        {
            builder.ToTable("Week");

            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.Bookings).WithOne().HasForeignKey(b => b.WeekId);

            //builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId); //dit is een relatie, dat moet je doen als iets niet in je tabel kan (dit is een one to many). deze had je evenwel bij customer kunnen defineren, maar hoeft maar in 1 van de twee
        }
    }
}
