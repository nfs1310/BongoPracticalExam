using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoPracticalExam
{
    class Problem1
    {
        public void Start()
        {
            string FilePath = @"G:\sTUDY\Visual Studio 2013\Projects\BongoPracticalExam\BongoPracticalExam\SampleJson.json";
            JObject JOb = JObject.Parse(File.ReadAllText(FilePath));

            SeperateEntries(JOb);
        }

        static int Depth = 0;

        static Dictionary<string, object> DeserializeJson(string ConvertedJsonString)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(ConvertedJsonString);
        }

        static void SeperateEntries(JObject JOb)
        {
            Depth++;
            string ConvertedJsonString = JsonConvert.SerializeObject(JOb).ToString();
            Dictionary<string, object> DataInDictionary = DeserializeJson(ConvertedJsonString);

            foreach (KeyValuePair<string, object> Entry in DataInDictionary)
            {
                //Type testType = Entry.Value.GetType();
                if (Entry.Value is JObject)
                {
                    Console.WriteLine("{0} {1}", Entry.Key, Depth);
                    SeperateEntries((JObject)Entry.Value);
                }
                else
                {
                    Console.WriteLine("{0} {1}", Entry.Key, Depth);
                }
            }
        }
    }
}
