using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalAdoption.Common.Logic
{
    public class CartService
    {
        private IMemoryCache _cache;
        private AnimalService _animalData;
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);

        public CartService(IMemoryCache memoryCache, AnimalService animalData)
        {
            _cache = memoryCache;
            _animalData = animalData;
        }

        public Cart SetAnimalQuantity(string cartId, int animalId, int quantity)
        {
            semaphoreSlim.Wait(TimeSpan.FromSeconds(1).Milliseconds);
            try
            {
                var domainCart = _cache.Get<CartData>(cartId);

                if (domainCart == null)
                {
                    domainCart = new CartData();
                };

                if (quantity < 1)
                {
                    domainCart.CartContents.Remove(animalId);
                }
                else if (domainCart.CartContents.ContainsKey(animalId))
                {
                    domainCart.CartContents[animalId] = quantity;
                }
                else
                {
                    domainCart.CartContents.Add(animalId, quantity);
                }

                _cache.Set(cartId, domainCart);
                return ListAnimals(cartId);
            }
            finally
            {
                semaphoreSlim.Release();
            }

        }

        public Cart ListAnimals(string cartId)
        {
            var domainCart = _cache.Get<CartData>(cartId);
            var allAnimals = _animalData.ListAnimals;


            var cartContents = allAnimals.Select(animal =>
            {
                int quantity = 0;
                domainCart?.CartContents.TryGetValue(animal.Id, out quantity);
                return new CartContent
                {
                    Id = animal.Id,
                    Name = animal.Name,
                    Quantity = quantity
                };
            });

            return new Cart
            {
                Id = cartId,
                CartContents = cartContents
            };
        }
    }
}
