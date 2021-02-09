using NUnit.Framework;
using TestNinja.Fundamentals;

namespace api.tests
{
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true});

            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false});

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnsFalse()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }
        
    }
}