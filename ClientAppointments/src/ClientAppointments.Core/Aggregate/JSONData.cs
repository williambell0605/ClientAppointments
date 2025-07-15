using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointments.Core.Aggregate
{
	public class RootJSONDataObject
	{
		public JSONData[] JSONDatas { get; set; }
	}
	public class JSONData
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
