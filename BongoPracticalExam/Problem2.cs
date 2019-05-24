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
    class Problem2
    {
        static Dictionary<string, object> ClassObjects = new Dictionary<string, object>();
        static JObject ClassJOb;

        public void Start()
        {
            string FilePath = @"G:\sTUDY\Visual Studio 2013\Projects\BongoPracticalExam\BongoPracticalExam\SampleJson2.json";
            JObject JOb = JObject.Parse(File.ReadAllText(FilePath));

            Person person_a = new Person("User", "1", "none");
            Person person_b = new Person("User", "1", person_a);

            ClassObjects.Add("person_a", person_a);
            ClassObjects.Add("person_b", person_b);

            ClassJOb = JObject.Parse(JsonConvert.SerializeObject(person_b));
            
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
                else if (ClassObjects.ContainsKey(Entry.Value.ToString()))
                {
                    SeperateEntries(ClassJOb);
                }
                else
                {
                    Console.WriteLine("{0} {1}", Entry.Key, Depth);
                }
            }
        }
    }
    public class Person
    {
        public string _first_name, _last_name;
        public object _father;
        public Person(string first_name, string last_name, object father)
        {
            this._first_name = first_name;
            this._last_name = last_name;
            this._father = father;
        }
    }
}
