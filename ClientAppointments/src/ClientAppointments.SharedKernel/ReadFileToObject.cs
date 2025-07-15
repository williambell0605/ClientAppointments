using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointments.SharedKernel
{
    public class ReadFileToObject<T>
    {
        public ReadFileToObject()
        { }
        public static List<T> ConvertToObject(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                return result;
            }
        }
    }
}
