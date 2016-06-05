using SmartCalendar.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartCalendar.Client.Win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int temp = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Events> GetListFromJson(string json)
        {
            var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Events>>(json);
            foreach(var element in ret)
            {
                if (string.IsNullOrEmpty(element.event_desc))
                    throw new Exception("description not set");
            }
            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;
            string fileText = GetFileContent(filePath);
            var itemList = GetListFromJson(fileText);
            bool resultOfInsert = insertItemListToDb(itemList);
            
            label.Content = resultOfInsert ? "Insert success!" : "Insert failed";


        }

        private bool insertItemListToDb(List<Events> itemList)
        {
            return temp++%2==0;
        }

        private string GetFileContent(string filePath)
        {
            var ev = new List<Events>();
            ev.Add(new Events()
            {
                event_name = "a",
                event_desc = "b",
                event_location = "jerusalem",
                event_datetimeUTC = DateTime.Now
            });
            ev.Add(new Events()
            {
                event_name = "a",
                event_desc = "b",
                event_location = "jerusalem",
                event_datetimeUTC = DateTime.Now
            });
            ev.Add(new Events()
            {
                event_name = "a",
                event_desc = "b",
                event_location = "jerusalem",
                event_datetimeUTC = DateTime.Now
            });
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ev);
            return json;
        }
    }
}
