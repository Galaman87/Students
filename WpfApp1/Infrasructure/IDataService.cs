using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Infrasructure
{
    public interface IDataService <T>
    {
        void Save(ObservableCollection<T> collection);
        ObservableCollection<T> Load();
        
    }
}
