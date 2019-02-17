using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lyubomirp.Models
{
    public class ProgramsList
    {
        [Key]
        public int Id { get; set; }

        public string programsAndIDEs { get; set; }
    }
}
