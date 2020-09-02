using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "Giraffe", Age = 50, Description = "A new born!" },
            new Animal { Id = 2, Name = "Dog", Age = 50, Description = "Very happy" },
            new Animal { Id = 3, Name = "Cat", Age = 50, Description = "Fluffy" },
        };
    }
}
