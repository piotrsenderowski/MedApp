//using MedApp.Core.Criterias;
//using MedApp.Core.Entities;
//using MedApp.Core.Repositories;
//using Microsoft.EntityFrameworkCore;
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
//        private readonly MedAppDbContext _dbContext;

//        public VisitsCritieraDoctorName(IUserRepository userRepository, MedAppDbContext dbContext)
//        {
//            _userRepository = userRepository;
//            _dbContext = dbContext;
//        }

//        public async Task<IEnumerable<Visit>> MeetCriteria(IEnumerable<Visit> visits, object criterium)
//        {
//            var doctor = await _dbContext.Visits.Include(x => x.
//            var doctorsVisits = visits.Where(x => x.UserName.ToLowerInvariant == criterium.ToString().ToLowerInvariant).ToList();
//            return doctorsVisits;
//        }
//    }
//}
