using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int MonthNumber { get; set; }
        public int Year { get; set; }
        public bool[] CompleteDays { get; set; }
        public bool Complete { get; set; }
    }
}