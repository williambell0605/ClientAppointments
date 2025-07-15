using Ardalis.Result;
using ClientAppointments.Core.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientAppointments.Core.Interfaces
{
    public interface IPractitionerSearchService
    {
        Task<Result<List<Practitioner>>> GetAllPractitioners(string fromDate, string toDate);
        Task<Result<List<Appointment>>> GetAppointments(int Id,string fromDate, string toDate);
            
    }
}
