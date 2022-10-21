//using MedApp.Core.Entities;
//using MedApp.Core.Exceptions;
//using MedApp.Core.ValueObjects;
//using Shouldly;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace MedApp.Tests.Unit.Entities
//{
//    public class MonthlyConsultationRoomTests
//    {
//        [Theory]
//        [InlineData("2022-08-10")]
//        [InlineData("2022-11-05")]
//        public void given_invalid_date_add_visit_should_fail(string dateString)
//        {
//            //ARRANGE
//            var invalidDate = DateTime.Parse(dateString);
//            var visit = new AppointmentVisit(Guid.NewGuid(), _monthlyConsultationRoom.Id, "JohnDoe", 
//                "JohnDoctor", 1, new Date(invalidDate));

//            //ACT
//            var exception = Record.Exception(() => _monthlyConsultationRoom.AddVisit(visit, _now));

//            //ASSERT
//            exception.ShouldNotBeNull();
//            exception.ShouldBeOfType<InvalidVisitDateException>();

//        }

//        [Fact]
//        public void given_visit_for_already_reserved_consultation_room_add_visit_should_fail()
//        {
//            var visitDate = _now.AddDays(1);
//            var visit = new AppointmentVisit(Guid.NewGuid(), _monthlyConsultationRoom.Id, "JohnDoe",
//                "JohnDoctor", 2, visitDate);
//            var nextVisit = new AppointmentVisit(Guid.NewGuid(), _monthlyConsultationRoom.Id, "JohnDoe",
//                "JohnDoctor", 1, visitDate);
//            _monthlyConsultationRoom.AddVisit(visit, _now);


//            var exception = Record.Exception(() => _monthlyConsultationRoom.AddVisit(nextVisit, visitDate));

//            exception.ShouldNotBeNull();
//            exception.ShouldBeOfType<ConsultationRoomCapacityExceededException>();
//        }

//        [Fact]
//        public void given_visit_for_not_reserved_consultation_room_add_visit_should_succeed()
//        {
//            var visitDate = _now.AddDays(1);
//            var visit = new AppointmentVisit(Guid.NewGuid(), _monthlyConsultationRoom.Id, "JohnDoe",
//                "JohnDoctor", 2, visitDate);


//            _monthlyConsultationRoom.AddVisit(visit, _now);


//            _monthlyConsultationRoom.Visits.ShouldHaveSingleItem();
//        }

//        #region Arrange
//        private readonly Date _now;
//        private readonly ConsultationRoom _monthlyConsultationRoom;

//        public MonthlyConsultationRoomTests()
//        {
//            _now = new Date(new DateTime(2022, 08, 22));
//            _monthlyConsultationRoom = ConsultationRoom.Create(Guid.NewGuid(), new Month(_now), "CR1");
//        }

//        #endregion
//    }
//}
