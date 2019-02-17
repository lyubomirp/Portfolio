using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lyubomirp.Models
{
    public class ProjectsAndIDEs
    {
        public ProjectsAndIDEs()
        {

        }

        public IEnumerable<Models.Summary> Technologies { get; set; }
        public IEnumerable<Models.ProgramsList> Programs { get; set; }
    }
}
