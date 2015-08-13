using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Infrastructure.Web.Grid
{
    [DataContract]
    public class GridFilter
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public GridRule[] rules { get; set; }

        public static GridFilter Create(string jsonData)
        {
            try
            {
                var serializer =
                  new DataContractJsonSerializer(typeof(GridFilter));
                System.IO.StringReader reader =
                  new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms =
                  new System.IO.MemoryStream(
                  Encoding.Default.GetBytes(jsonData));
                return serializer.ReadObject(ms) as GridFilter;
            }
            catch
            {
                return null;
            }
        }
    }
}
