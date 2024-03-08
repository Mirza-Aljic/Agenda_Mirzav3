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
        DAO_Contact Contact_DB;
        public MainWindow()
        {
            InitializeComponent();

            Contact_DB = new DAO_Contact();
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();
        }

        private void BTN_AddContact_Click(object sender, RoutedEventArgs e)
        {
            Add_Contact add_Contact = new Add_Contact();
            this.Content = add_Contact;
        }

        private void BTN_Modify_Click(object sender, RoutedEventArgs e)
        {
            Contact contacte = DG_Contact.SelectedItem as Contact;
            Contact_DB.UpdateContact(contacte);
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();
        }

        private void BTN_Delate_Click(object sender, RoutedEventArgs e)
        {
            Contact contacte = DG_Contact.SelectedItem as Contact;
            Contact_DB.DelateContact(contacte.Id);
            DG_Contact.ItemsSource = Contact_DB.GetAllContacts();
        }
    }
}
