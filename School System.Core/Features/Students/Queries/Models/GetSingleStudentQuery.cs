﻿using MediatR;
using School_System.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Core.Features.Students.Queries.Models
{
    public class GetSingleStudentQuery : IRequest<GetStudentResponse>
    {
        public int id {  get; set; }
        public GetSingleStudentQuery(int id)
        {
            this.id = id;
        }
    }
}
