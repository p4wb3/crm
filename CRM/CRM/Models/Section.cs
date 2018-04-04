﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Section
    {

        [Key]
        public string SectionName { get; set; }
        public string Job { get; set; }

        public List<Employee> People { get; set; }
    }
}