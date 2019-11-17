using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pencil42App.Test.MockRepositories;
using Pencil42App.Web.Controllers;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using static Pencil42App.Web.Entities.Time_registering;
using Microsoft.AspNetCore.Mvc;
// using CustomerEntity = Bookstore.Web.Entities.Customer;
using Moq;
using Microsoft.AspNetCore.Http;

namespace Pencil42App.Test.Controllers{    [TestClass]    public class SuggestionsControllerTests    { 
        // StatusCodes seem to not work

        /// <summary>
        /// Get Tests
        /// </summary>
        
        [ProducesResponseType(typeof(Suggestion), StatusCodes.Status200OK)]
        [TestMethod]
        public void ShouldGetSuggestionWithId42()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(new Suggestion { Id = 42 });
            var mockBookingReposiroty = new Mock<IBookingRepository>();

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            ActionResult<Suggestion> actionResult = sut.GetSuggestion(42);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(42));
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Suggestion>));
        }

        [ProducesResponseType(typeof(Suggestion), StatusCodes.Status404NotFound)]
        [TestMethod]
        public void ShouldNotGetSuggestionWithId24()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(24))
                .Returns(value: null);
            var mockBookingReposiroty = new Mock<IBookingRepository>();

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            ActionResult<Suggestion> actionResult = sut.GetSuggestion(24);
            Suggestion resultValue = actionResult.Value;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNull(resultValue);
        }

        /// <summary>
        /// Post tests
        /// </summary>

        [TestMethod]
        public void ShouldAddSuggestion()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(value: null);
            var mockBookingReposiroty = new Mock<IBookingRepository>();
            Suggestion sugg = new Suggestion()
            {
                Id = 42,
                UserId = 1,
                Name = "dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "dit is een beschrijving",
                Milestone = "dit is een milestone",
                Type = BookingType.Training
            };

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            IActionResult actionResult = sut.AddSuggestion(sugg,1);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(42));
            mockSuggestionRepository.Verify(mock => mock.Add(sugg), Times.Once);
        }

        [TestMethod]
        public void ShouldNotAddSuggestion()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(new Suggestion { Id = 42 });
            var mockBookingReposiroty = new Mock<IBookingRepository>();
            Suggestion sugg = new Suggestion()
            {
                UserId = 1,
                Id = 42,
                Name = "Dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "dit is een beschrijving",
                Milestone = "dit is een milestone",
                Type = BookingType.Training
            };

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            IActionResult actionResult = sut.AddSuggestion(sugg,1);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(42));
            mockSuggestionRepository.Verify(Mock => Mock.Add(sugg), Times.Never);
        }

        /// <summary>
        /// Update tests
        /// </summary>


        [TestMethod]
        public void ShouldUpdateSuggestion()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(new Suggestion { Id = 42 });
            var mockBookingReposiroty = new Mock<IBookingRepository>();
            Suggestion sugg = new Suggestion()
            {
                UserId = 1,
                Id = 42,
                Name = "Dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "dit is een beschrijving",
                Milestone = "dit is een milestone",
                Type = BookingType.Training
            };

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            IActionResult actionResult = sut.UpdateSuggestion(42, sugg, 1);

            // Assert
            Assert.IsNotNull(actionResult);
            // TODO: mockSuggestionRepository.Verify(mock => mock.Get(42));
            // Passes but is wrong: mockSuggestionRepository.Verify(mock => mock.Update(1, sugg), Times.Once);
            mockSuggestionRepository.Verify(mock => mock.Update(42, sugg), Times.Once);
        }

        [TestMethod]
        public void ShouldNotUpdateSuggestion()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(value: null);
            var mockBookingReposiroty = new Mock<IBookingRepository>();
            Suggestion sugg = new Suggestion()
            {
                UserId = 1,
                Id = 42,
                Name = "Dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "dit is een beschrijving",
                Milestone = "dit is een milestone",
                Type = BookingType.Training
            };

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            IActionResult actionResult = sut.UpdateSuggestion(42, sugg, 1);

            // Assert
            Assert.IsNotNull(actionResult);
            // TODO: mockSuggestionRepository.Verify(mock => mock.Get(42));
            mockSuggestionRepository.Verify(Mock => Mock.Update(42, sugg), Times.Never);
        }

        /// <summary>
        /// Delete tests
        /// </summary>

        [ProducesResponseType(typeof(Suggestion), StatusCodes.Status200OK)]
        [TestMethod]
        public void ShouldDeleteSuggestionWithId42()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(new Suggestion { Id = 42 });
            var mockBookingReposiroty = new Mock<IBookingRepository>();

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            ActionResult actionResult = sut.DeleteSuggestion(42);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(42));
            mockSuggestionRepository.Verify(mock => mock.Delete(42), Times.Once);
        }

        [ProducesResponseType(typeof(Suggestion), StatusCodes.Status404NotFound)]
        [TestMethod]
        public void ShouldNotDeleteSuggestionWithId24()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(24))
                .Returns(value: null);
            var mockBookingReposiroty = new Mock<IBookingRepository>();

            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            ActionResult actionResult = sut.DeleteSuggestion(24);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(24));
            mockSuggestionRepository.Verify(mock => mock.Delete(24), Times.Never);
        }

        /// <summary>
        /// AddSuggestionToWeekTests
        /// </summary>

        /*[TestMethod]
        public void ShouldAddSuggestionToWeek()
        {
            // Arrange
            var mockSuggestionRepository = new Mock<ISuggestionRepository>();
            mockSuggestionRepository.Setup(x => x.Get(42))
                .Returns(value: null);
            var mockBookingReposiroty = new Mock<IBookingRepository>();
            var addSuggestion = new addSuggestion();
            var sut = new SuggestionsController(mockSuggestionRepository.Object, mockBookingReposiroty.Object);

            // Act
            ActionResult actionResult = sut.AddSuggestionToWeek(42,1,);

            // Assert
            Assert.IsNotNull(actionResult);
            mockSuggestionRepository.Verify(mock => mock.Get(24));
            mockSuggestionRepository.Verify(mock => mock.Delete(24), Times.Never);
        }*/

        // ============================

        /*[TestMethod]
        public void ShouldAddSuggestionWithId1()
        {
            // arrange
            MockContext context = new MockContext();
            ISuggestionRepository suggestionRepository = new MockSuggestionRepository(context);
            IBookingRepository bookingRepository = new MockBookingRepository();
            SuggestionsController sut = new SuggestionsController(suggestionRepository, bookingRepository);
            Suggestion sugg = new Suggestion()
            {
                Id = 1,
                Name = "Dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "In MockContext",
                Milestone = "Mocking context",
                Type = BookingType.Training
            };

            // act
            sut.AddSuggestion(sugg,1);

            // Assert
            Assert.IsTrue(context.Suggestions.Contains(sugg));

        }*/


        /*
        //private CustomerEntity _entity;
        //private Customer _customer;
        //
        //public CustomerTests()
        //{
        //    this._entity = new CustomerEntity { Name = "name1" };
        //    this._customer = new Customer(this._entity);
        //}

        /*          * geen database gebruiken in tests         * asserts enkel op System Under Test         * black box testen zijn testen die je voor implementatie zou schrijven         *         */
        /*
        [TestMethod]        public void ShouldChangeNameOfTheUnderlyingEntity()        {
            // arrange
            string newName = "name2";            CustomerEntity entity = new CustomerEntity { Name = "name1" };            Customer sut = new Customer(entity);

            // act
            sut.ChangeName(newName);

            // assert
            // NOT OK (white box)
            Assert.AreEqual(newName, entity.Name);

            // Ok black box
            Assert.AreEqual(newName, sut.Name);        }        [ExpectedException(typeof(NotAllowedException))]        [TestMethod]        public void ShouldNotAllowEmptyName()        {
            // arrange
            string newName = "";            CustomerEntity entity = new CustomerEntity { Name = "name1" };            Customer sut = new Customer(entity);

            // act
            sut.ChangeName(newName);        }        [TestMethod]        public void ShouldChangeName()        {
            // arrange
            string newName = "name2";            var mock = new Mock<CustomerEntity>();            Customer sut = new Customer(mock.Object);

            // act
            sut.ChangeName(newName);

            // Ok black box
            Assert.AreEqual(newName, sut.Name);        }        [TestMethod]        public void ShouldReturnProperName()        {
            // arrange
            string name = "name2";            Mock<CustomerEntity> mock = new Mock<CustomerEntity>();            mock.SetupGet(m => m.Name).Returns(name);            Customer sut = new Customer(mock.Object);


            // Ok black box
            Assert.AreEqual(name, sut.Name);        }        */
    }}