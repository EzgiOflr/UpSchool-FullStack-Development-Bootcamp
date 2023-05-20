using FakeItEasy;
using System.Linq.Expressions;
using System.Threading;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            var exceptionNull = await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("ezgi", "oflar", 24, null, cancellationSource.Token));
            var exceptionEmpty = await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("ezgi", "oflar", 24, String.Empty, cancellationSource.Token));

            Assert.Equal("Email cannot be null or empty.", exceptionNull.Message);
            Assert.Equal("Email cannot be null or empty.", exceptionEmpty.Message);

        }


        [Fact]
        public async Task AddAsync_ShouldReturn_CorrectUserId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.AddAsync(expectedUser, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            var userGuid = await userService.AddAsync("ezgi", "oflar", 24, "eo@gmail.com", cancellationSource.Token);


            Assert.IsType<Guid>(userGuid);
            Assert.NotEqual(Guid.Empty, userGuid);
        }


        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);


            var cancellationSource = new CancellationTokenSource();

            var user = new User
            {
                Id = Guid.Empty, // Empty UserId
                Email = "ezgi@example.com"
            };


            var exception = await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(user, cancellationSource.Token));

            Assert.Equal("User Id cannot be null or empty.", exception.Message);
        }

        [Fact]
   
        public async Task UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            var userNullEmail = new User()
            {
                Id = Guid.NewGuid(),
                Email=null
            };

            var userEmptyEmail = new User()
            {
                Id = Guid.NewGuid(),
                Email = String.Empty
            };

            var isNull = await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(userNullEmail, cancellationSource.Token));
            var isEmpty = await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(userEmptyEmail, cancellationSource.Token));

            Assert.Equal("Email cannot be null or empty.", isNull.Message);
            Assert.Equal("Email cannot be null or empty.", isEmpty.Message);
        }



        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var cancellationSource = new CancellationTokenSource();

            var expectedUsers = new List<User>
            {
                new User { Id = Guid.NewGuid() },
                new User { Id = Guid.NewGuid() }
            };

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token))
                .Returns(Task.FromResult(expectedUsers));

            // Act
            var users = await userService.GetAllAsync(cancellationSource.Token);

            // Assert
            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.True(users.Count >= 2);
        }


        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();
            IUserService userService = new UserManager(userRepositoryMock);

            var cancellationSource = new CancellationTokenSource();
            var userId = Guid.NewGuid();

            A.CallTo(() => userRepositoryMock.DeleteAsync(A<Expression<Func<User, bool>>>.Ignored, cancellationSource.Token))
                .Returns(Task.FromResult(1)); 

            // Act
            var result = await userService.DeleteAsync(userId, cancellationSource.Token);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExist()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            var exception = await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(Guid.Empty, cancellationSource.Token));

            Assert.Equal("id cannot be empty.", exception.Message);
        }

    }
}




