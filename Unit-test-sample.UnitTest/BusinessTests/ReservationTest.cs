
using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest.BusinessTest
{
    
     //mStEST: [TestClass]
     [TestFixture]
    public class ReservationTest //name of the class we are testing for
    {
        //msTest: [TestMethod]
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue() //test one of the exceution paths(logic/condition)
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true });

            //Assert
            //MsTest: Assert.IsTrue(result);
            Assert.That(result == true);
        }

         [Test]
        public void CanBeCancelledBy_IsSameUser_ReturnsTrue() //test one of the exceution paths(logic/condition)
        {
            //Arrange
             var user = new User { IsAdmin = true };
            var reservation = new Reservation{ MadeBy = user };

            //Act
           var result = reservation.CanBeCancelledBy(user);

            Assert.That(result == true);
        }

            [Test]
        public void CanBeCancelledBy_UserNotAdminAndNotSameUser_ReturnsFalse() //test one of the exceution paths(logic/condition)
        {
            // //Arrange
             var user = new User();
            var reservation = new Reservation { MadeBy = new User()};
         
            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
             Assert.That(result == false);
        }
    }
}
