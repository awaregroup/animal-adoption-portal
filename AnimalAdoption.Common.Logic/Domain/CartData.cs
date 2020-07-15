using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class CartData
    {
        public Dictionary<int, int> CartContents { get; set; } = new Dictionary<int, int>();
    }
}
