using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "cat", Age = 40, Description = "a small domesticated carnivorous mammal with soft fur, a short snout, and retractable claws. It is widely kept as a pet or for catching mice, and many breeds have been developed." },
            new Animal { Id = 2, Name = "dog", Age = 30, Description = "a domesticated carnivorous mammal that typically has a long snout, an acute sense of smell, nonretractable claws, and a barking, howling, or whining voice." },
            new Animal { Id = 3, Name = "duck", Age = 20, Description = "a waterbird with a broad blunt bill, short legs, webbed feet, and a waddling gait." },
        };
    }
}
