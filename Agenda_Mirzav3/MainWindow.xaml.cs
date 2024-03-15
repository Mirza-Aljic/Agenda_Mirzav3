using Agenda_Mirzav3.Service.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agenda_Mirzav3.AgendaMirzaDB;
using Agenda_Mirzav3.Service.DAO;
using Agenda_Mirzav3.View;

namespace Agenda_Mirzav3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BTN_Contact_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            View.PageContact contact = new View.PageContact();
            Window_Container.Children.Add(contact);
        }

        private void BTN_To_Do_List_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            View.To_Do_List to_do_list = new View.To_Do_List();
            Window_Container.Children.Add(to_do_list);
        }

        private void BTN_Calendar_Click(object sender, RoutedEventArgs e)
        {
            Window_Container.Children.Clear();
            View.Calendar calendar = new View.Calendar();
            Window_Container.Children.Add(calendar);
        }
    }
}
