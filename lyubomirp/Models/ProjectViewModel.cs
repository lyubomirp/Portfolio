using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lyubomirp.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProjectLink { get; set; }

        public string Content { get; set; }

        public IFormFile ImagePath { get; set; }
    }
}
