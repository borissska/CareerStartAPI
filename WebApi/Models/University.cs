﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public int PlaceId { get; set; }
        public ICollection<EducationalProgramme> EducationalProgrammes { get; set; }

        public University()
        {
            EducationalProgrammes = new List<EducationalProgramme>();
        }
    }
}
