using Bookify.Domain.UnitTests.Infrastructure;
using Bookify.Domain.Users;
using Bookify.Domain.Users.Events;
using FluentAssertions;

namespace Bookify.Domain.UnitTests.Users;

public partial class UserTests : BaseTests
{
    [Fact]
    public void Create_Should_SetPropertyValues()
    {
        //Arrange UserData.cs already created

        //Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);

        //Assert
        user.FirstName.Should().Be(UserData.FirstName);
        user.LastName.Should().Be(UserData.LastName);
        user.Email.Should().Be(UserData.Email);
    }

    [Fact]
    public void Create_Should_RaiseUserDomainEvent()
    {
        //Arrange UserData.cs already created

        //Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);

        //Assert
        //var domainEvent = user.GetDomainEvents().OfType<UserCreatedDomainEvent>().FirstOrDefault();
        var domainEvent = AssertDomainEventPublished<UserCreatedDomainEvent>(user);
        domainEvent.UserId.Should().Be(user.Id);
    }

    [Fact]
    public void Create_Should_AddRegisteredRoleToUser()
    {
        //Arrange UserData.cs already created

        //Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);

        //Assert
        user.Roles.Should().Contain(Role.Registered);
    }
}
