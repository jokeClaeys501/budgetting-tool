using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pencil42App.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope()) //zorgt ervoor dat je niet scope.dispose expliciet moet doen
            {

                var ctx = scope.ServiceProvider.GetService<App42Context>(); // vraagt aan zak heb je een bookstorecontext voor me
                var repository = scope.ServiceProvider.GetService<IUserRepository>(); // geb he eeb repository voor mij
                var repositoryweek = scope.ServiceProvider.GetService<IWeekRepository>();
                var bookingrepository = scope.ServiceProvider.GetService<IBookingRepository>();
                
                var seed = new Seed(repository, repositoryweek, bookingrepository, ctx);
                seed.Run();
            }

            return app;
        }
    }
}


