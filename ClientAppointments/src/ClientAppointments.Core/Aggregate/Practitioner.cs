using ClientAppointments.SharedKernel;

namespace ClientAppointments.Core.ProjectAggregate
{ 
    public class RootPractitionersObject
    {
        public Practitioner[] Practitioners { get; set; }
    }

    public class Practitioner
    {
        public int id { get; set; }
        public string name { get; set; }

        public int yearId { get; set; }
        public int monthId { get; set; }
        public string monthName { get; set; }
        public int revenue { get; set; }
        public int cost { get; set; }
    }

}
