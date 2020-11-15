using Futoszalag.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futoszalag.Entities
{
    public class ToyFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
