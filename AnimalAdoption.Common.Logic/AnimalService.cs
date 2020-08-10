using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "Sedi", Age = 50, Description = "Soft natured" },
            new Animal { Id = 2, Name = "Metamorph", Age = 50, Description = "Under a lot of pressure" },
            new Animal { Id = 3, Name = "Igno", Age = 50, Description = "Shiny and glasslike" },
        };
    }
}
