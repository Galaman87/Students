using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Infrasructure;
using WpfApp1.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace WpfApp1.Json
{
    class JsonDataService : IDataService<Student>
    {
        public JsonDataService(string filename)
        {
            this.file = filename;
        }
        string file;
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));
        public ObservableCollection<Student> Load()
        {
            ObservableCollection<Student> students;
            if (!File.Exists(file))
                students = new ObservableCollection<Student>();
            string json = File.ReadAllText(file);
            return students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(json);
        }


        public void Save(ObservableCollection<Student> collection)
        {
            string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
            File.WriteAllText(file, json);
        }

    }
}
