﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Queries.Results
{
    public class GetStudentListResponse
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Department { get; set; }
    }
}
