namespace AnimalAdoption.Common.Logic
{
	public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "Noelle", Age = 20, Description = "Shiny and glasslike" },
            new Animal { Id = 2, Name = "Rabbit Won", Age = 20, Description = "Under a lot of pressure" },
            new Animal { Id = 3, Name = "Tasha", Age = 20, Description = "Soft natured" },
        };
    }
}
