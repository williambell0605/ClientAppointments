using Ardalis.GuardClauses;
using Ardalis.Result;
using ClientAppointments.Core.Interfaces;
using ClientAppointments.Core.ProjectAggregate;
using ClientAppointments.SharedKernel.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ClientAppointments.SharedKernel;

namespace ClientAppointments.Core.Services
{
    public class PractitionerSearchService : IPractitionerSearchService
    {
        private readonly string _practitionersFileName = "wwwroot/DataSource/practitioners.json";
        private readonly string _appointmentsFileName = "wwwroot/DataSource/appointments.json";

        private readonly List<Practitioner> _practitionerList = new List<Practitioner>();
        private readonly List<Appointment> _appointmentList = new List<Appointment>();

        public PractitionerSearchService()
        {
            _practitionerList = ReadFileToObject<Practitioner>.ConvertToObject(_practitionersFileName);
            _appointmentList = ReadFileToObject<Appointment>.ConvertToObject(_appointmentsFileName);
        }

        public async Task<Result<List<Practitioner>>> GetAllPractitioners(string fromDate, string toDate)
        { 
            DateTime startDate = Convert.ToDateTime(fromDate);
            DateTime endDate = Convert.ToDateTime(toDate);
            if (startDate.Year == 1900 || endDate.Year == 1900)
            {
                var errors = new List<ValidationError>();
                if (startDate.Year == 1900)
                {
                    errors.Add(new ValidationError()
                    {
                        Identifier = nameof(startDate),
                        ErrorMessage = $"{nameof(startDate)} is not valid."
                    });
                }
                if (endDate.Year == 1900)
                {
                    errors.Add(new ValidationError()
                    {
                        Identifier = nameof(endDate),
                        ErrorMessage = $"{nameof(endDate)} is not valid."
                    });
                }
                return Result<List<Practitioner>>.Invalid(errors);
            }

            var result = (from p in _practitionerList
                          join a in _appointmentList.Where(a => a.date >= startDate && a.date <= endDate)
                          on p.id equals a.practitioner_id
                          select new
                          {
                              YearId = a.date.Year,
                              MonthId = a.date.Month,
                              a.revenue,
                              a.cost,
                              p.id,
                              p.name,
                              MonthName = a.date.ToString("MMM-yyyy")
                          }).ToList().GroupBy(a => new
                          {
                              a.id,
                              a.YearId,
                              a.MonthId
                          }).Select(s => new Practitioner
                          {
                              id = s.FirstOrDefault().id,
                              name = s.FirstOrDefault().name,
                              yearId = s.FirstOrDefault().YearId,
                              monthId = s.FirstOrDefault().MonthId,
                              revenue = s.Sum(ss => ss.revenue),
                              cost = s.Sum(ss => ss.cost),
                              monthName = s.FirstOrDefault().MonthName
                          })
                          .OrderBy(a => a.id)
                          .ThenBy(a => a.yearId)
                          .ThenBy(a => a.monthId).ToList();


            if (result == null) return Result<List<Practitioner>>.NotFound();
            try
            {
                return new Result<List<Practitioner>>(result);
            }
            catch (Exception ex)
            {
                return Result<List<Practitioner>>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<List<Appointment>>> GetAppointments(int Id, string fromDate, string toDate)
        {
            DateTime startDate = Convert.ToDateTime(fromDate);
            DateTime endDate = Convert.ToDateTime(toDate);

            if (startDate.Year == 1900 || endDate.Year == 1900)
            {
                var errors = new List<ValidationError>();
                if (startDate.Year == 1900)
                {
                    errors.Add(new ValidationError()
                    {
                        Identifier = nameof(startDate),
                        ErrorMessage = $"{nameof(startDate)} is not valid."
                    });
                }
                if (endDate.Year == 1900)
                {
                    errors.Add(new ValidationError()
                    {
                        Identifier = nameof(endDate),
                        ErrorMessage = $"{nameof(endDate)} is not valid."
                    });
                }
                return Result<List<Appointment>>.Invalid(errors);
            }

            var result = (from a in _appointmentList
                          where a.date >= startDate && a.date <= endDate && a.practitioner_id == Id
                          select a
                          ).OrderBy(a => a.date).ToList();


            if (result == null) return Result<List<Appointment>>.NotFound();
            try
            {
                return new Result<List<Appointment>>(result);
            }
            catch (Exception ex)
            {
                return Result<List<Appointment>>.Error(new[] { ex.Message });
            }
        }
    }
}
