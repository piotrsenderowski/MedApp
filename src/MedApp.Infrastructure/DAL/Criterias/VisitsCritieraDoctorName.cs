//using MedApp.Core.Criterias;
//using MedApp.Core.Entities;
//using MedApp.Core.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MedApp.Infrastructure.DAL.Criterias
//{
//    internal class VisitsCritieraDoctorName : IVisitsCriteria
//    {
//        private readonly IUserRepository _userRepository;

//        public VisitsCritieraDoctorName(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<IEnumerable<Visit>> MeetCriteria(IEnumerable<Visit> visits, object criterium)
//        {
//            var doctor = await _userRepository.GetByIdAsync()
//            var doctorsVisits = visits.Where(x => x.UserName.ToLowerInvariant == criterium.ToString().ToLowerInvariant).ToList();
//            return doctorsVisits;
//        }
//    }
//}
