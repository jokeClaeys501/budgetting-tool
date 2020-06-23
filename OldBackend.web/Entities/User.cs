using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int HoursToWorkInAWeek { get; set; }
        public virtual ICollection<Suggestion> Suggestions { get; set; }// one-to-many
        public virtual ICollection<Week> Weeks { get; set; }
    }
}
