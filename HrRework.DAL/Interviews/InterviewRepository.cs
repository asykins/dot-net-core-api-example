using HrRework.Application.Interfaces;
using HrRework.DAL.Base;
using HrRework.Domain.Interviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.DAL.Interviews
{
    public class InterviewRepository : EntityFrameworkRepository<Interview>, IInterviewRepository
    {
        public InterviewRepository(DbContext HrReworkContext) 
            : base(HrReworkContext)
        {
        }
    }
}
