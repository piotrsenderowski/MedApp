//using MedApp.Application.Commands;
//using MedApp.Core.Abstractions;
//using MedApp.Core.DomainServices;
//using MedApp.Core.Policies;
//using MedApp.Core.Repositories;
//using MedApp.Infrastructure.DAL.Repositories;
//using MedApp.Tests.Unit.Shared;
//using Shouldly;
//using Xunit;

//namespace MedApp.Tests.Unit.Services
//{
//    public class VisitsServiceTests
//    {
//        [Fact]
//        public async Task given_visit_for_not_taken_date_create_visit_should_succeed()
//        {
//            // Arrange
//            var monthlyConsultationRoom = (await _monthlyConsultationRoomRepository.GetAllAsync()).First();
//            var command = new CreateVisit(monthlyConsultationRoom.Id, Guid.NewGuid(), 1,
//                "JohnDoe", DateTime.UtcNow.AddMinutes(5), "JohnDoctor");

//            // Act
//            var visitId = await _visitService.ReserveForAppointmentAsync(command);

//            // Assert
//            visitId.ShouldNotBeNull();
//            visitId.Value.ShouldBe(command.VisitId);

//        }

//        #region Arrange

//        private readonly IClock _clock;
//        private readonly IMonthlyConsultationRoomRepository _monthlyConsultationRoomRepository;
//        private readonly IVisitsService _visitService;

//        public VisitsServiceTests()
//        {
//            _clock = new TestClock();
//            _monthlyConsultationRoomRepository = new InMemoryMonthlyConsultationRoomRepository(_clock);

//            var consultationRoomVisitService = new ConsultationRoomVisitService(new IVisitPolicy[]
//            {
//                new OwnerVisitPolicy(),
//                new SpecialistVisitPolicy(),
//                new RegularVisitPolicy(_clock)
//            }, _clock);

//            _visitService = new VisitsService(_clock, _monthlyConsultationRoomRepository, consultationRoomVisitService);
//        }

//        #endregion
//    }
//}
