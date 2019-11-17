using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Entities
{
    public abstract class Time_registering
    {
        public int Id { get; set; }
        public string Milestone { get; set; }
        public enum BookingType { Administration, Consultancy, Sales, Training, Afspraak, Telefoongesprek }
        public BookingType Type { get; set; }
        public string Description { get; set; }
        
    }
}
