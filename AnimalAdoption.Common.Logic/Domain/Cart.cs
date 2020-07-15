using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class Cart
    {
        public string Id { get; set; }
        public IEnumerable<CartContent> CartContents { get; set; }
    }
}
