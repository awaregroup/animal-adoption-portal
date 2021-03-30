using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "Co", Age = 2, Description = "Cozy" },
            new Animal { Id = 2, Name = "Zebra", Age = 4, Description = "Luxury" },
            new Animal { Id = 3, Name = "Racoon", Age = 3, Description = "Fool" },
        };
    }
}
