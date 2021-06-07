using Bogus;
using Xunit;
using ConsoleAppRedTrust.Domain;

namespace ConsoleAppRedTrustTestProject
{
    public class CustomQueueUnitTest
    {
        
        [Fact]
        public void Can_Count()
        {
            // Arrange
            var faker = new Faker();
            var queue = new CustomQueue();
            
            // Act
            
            // Assert
            Assert.Equal(0, queue.Count());
        }
        
        [Fact]
        public void Count_Is_Not_Equal()
        {
            // Arrange
            var faker = new Faker();
            var queue = new CustomQueue();
            
            // Act
            
            // Assert
            Assert.NotEqual(1, queue.Count());
        }
        
        [Fact]
        public void Can_Enqueue_An_Element()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var queue = new CustomQueue();
            
            // Act
            queue.Enqueue(element);
            
            // Assert
            Assert.Equal(1, queue.Count());
        }
        
        [Fact]
        public void Dequeue_Element_Is_Not_Empty()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var queue = new CustomQueue();
            
            // Act
            queue.Enqueue(element);
            var item = queue.Dequeue();
            
            // Assert
            Assert.NotEmpty(item);
        }
        
        [Fact]
        public void Dequeue_Element_Is_Equal()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var queue = new CustomQueue();
            
            // Act
            queue.Enqueue(element);
            var item = queue.Dequeue();
            
            // Assert
            Assert.Equal(item, element);
        }
        
        [Fact]
        public void Dequeue_Element_Is_Different()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var differentElement = faker.Name.FullName();
            var queue = new CustomQueue();
            
            // Act
            queue.Enqueue(element);
            var item = queue.Dequeue();
            
            // Assert
            Assert.NotEqual(item, differentElement);
        }
        
        [Fact]
        public void Can_Not_Listen_Enqueue_Signal()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var queue = new CustomQueue();
            var signalListened = false;

            // Act
            queue.Enqueue(element);
            
            // Assert
            Assert.NotEqual(true, signalListened);
        }
        
        [Fact]
        public void Can_Listen_Enqueue_Signal()
        {
            // Arrange
            var faker = new Faker();
            var element = faker.Name.FullName();
            var queue = new CustomQueue();
            var signalListened = false;

            // Act
            queue.OnItemEnqueued += (sender, args) =>
            {
                signalListened = true;
            };
            
            queue.Enqueue(element);

            
            // Assert
            Assert.Equal(true, signalListened);
        }
    }
}