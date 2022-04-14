using Customer_service_app.Data;
using FluentAssertions;
using Xunit;

namespace CustomerTests
{
    public class CustomerTest
    {
        [Fact]
        public void ShouldSetModel()
        {
            //Arrange
            const string Id = "123";
            const string FirstName = "Mamad";
            const string LastName = "Jafari";
            const string PhoneNumber = "0912";
            //Act
            var customer = new Customer();
            customer.Id = Id;
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.PhoneNumber = PhoneNumber;
            //Assert
            customer.Id.Should().Be(Id);
            customer.FirstName.Should().Be(FirstName);
            customer.LastName.Should().Be(LastName);
            customer.PhoneNumber.Should().Be(PhoneNumber);
        }
    }
}