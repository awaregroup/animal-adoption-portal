using AnimalAdoption.Common.Logic;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using Xunit;

namespace AnimalAdoption.Service.Cart.UnitTests
{
    public class CartTests
    {
        private CartService _uut;

        private const int TestAnimalId = 1;
        private const string TestCartId = "TEST_CART_1";

        public CartTests()
        {
            _uut = new CartService(new MemoryCache(new MemoryCacheOptions()), new AnimalService());
        }

        [Fact]
        public void SetAnimalQuantity_AddsTheExpectedNumberOfAnimalsToTheCart_WhenTheNumberOfAnimalsToAddIsAboveZero()
        {
            // Arrange
            var expectedNumberOfAnimalsInCart = 1;
            var expectedCartId = TestCartId;

            var animalIdToAddToTheCart = TestAnimalId;
            var numberOfAnimalsToAddToTheCart = 1;

            // Act
            var resultingCart = _uut.SetAnimalQuantity(expectedCartId, animalIdToAddToTheCart, numberOfAnimalsToAddToTheCart);

            // Assert
            Assert.Equal(expectedCartId, resultingCart.Id);
            Assert.Equal(expectedNumberOfAnimalsInCart, resultingCart.CartContents.First(x=>x.Id == animalIdToAddToTheCart).Quantity);
        }

        [Fact]
        public void SetAnimalQuantity_DoesNotAddAnyAnimalsToTheCart_WhenTheNumberOfAnimalsToAddIsBelowZero()
        {
            // Arrange
            var expectedNumberOfAnimalsInCart = 0;
            var expectedCartId = TestCartId;

            var animalIdToAddToTheCart = TestAnimalId;
            var numberOfAnimalsToAddToTheCart = -1;

            // Act
            var resultingCart = _uut.SetAnimalQuantity(expectedCartId, animalIdToAddToTheCart, numberOfAnimalsToAddToTheCart);

            // Assert
            Assert.Equal(expectedCartId, resultingCart.Id);
            Assert.Equal(expectedNumberOfAnimalsInCart, resultingCart.CartContents.First(x => x.Id == animalIdToAddToTheCart).Quantity);
        }
    }
}
