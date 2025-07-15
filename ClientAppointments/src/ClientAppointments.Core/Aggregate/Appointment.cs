using Ardalis.GuardClauses;
using ClientAppointments.SharedKernel;
using ClientAppointments.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientAppointments.Core.ProjectAggregate
{ 
    public class RootAppointmentsObject
    {
     //   private List<ToDoItem> _items = new List<ToDoItem>();
      //  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
        public Appointment[] Appointments { get; set; }
    }

    public class Appointment
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string client_name { get; set; }
        public string appointment_type { get; set; }
        public int duration { get; set; }
        public int revenue { get; set; }
        public int cost { get; set; }
        public int practitioner_id { get; set; }
    }

}
