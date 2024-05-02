using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_System.Data.Common
{
    public abstract class BaseEntity<T> where T : notnull
    {
        public T Id { get; set; } = default!;
    }
}
