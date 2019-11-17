using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pencil42App.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Repositories.Map
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");

            builder.HasKey(b => b.Id);

            //builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId); //dit is een relatie, dat moet je doen als iets niet in je tabel kan (dit is een one to many). deze had je evenwel bij customer kunnen defineren, maar hoeft maar in 1 van de twee
        }

    }
}
