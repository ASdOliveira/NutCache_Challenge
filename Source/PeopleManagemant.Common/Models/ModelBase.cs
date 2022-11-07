using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Common.Models
{
    public abstract class ModelBase<T> where T : new()
    {
        public T Value { get; private set; } = new T();
        public abstract bool IsValid();
    }
}
