using Agenda_Mirzav3.AgendaMirzaDB;
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
using Agenda_Mirzav3.Service.DAO;
using Agenda_Mirzav3.View;

namespace Agenda_Mirzav3.View
{
    /// <summary>
    /// Logique d'interaction pour Add_Contact.xaml
    /// </summary>
    public partial class Add_Contact : UserControl
      
    {
        Contact contact;
        DAO_Contact dAO_Contact;
        public Add_Contact()
        {
            InitializeComponent();

            contact = new Contact();
            dAO_Contact = new DAO_Contact();
        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            contact.Nom = TB_Nom.Text;
            contact.Prenom = TB_Prenom.Text;
            contact.Sexe = TB_Sexe.Text;
            contact.Birthday = DateOnly.FromDateTime(DP_Birthday.SelectedDate.Value);
            contact.Email = TB_Email.Text;
            contact.Numero = TB_Numero.Text;
            contact.Status = TB_Status.Text;
            contact.Adresse = TB_Adresse.Text;

              dAO_Contact.AddContact(contact);
                MessageBox.Show("Contact ajouté avec succès");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Window.GetWindow(this).Close();
            
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            PageContact contact = new PageContact();
            this.Content = contact;
        }
    }
}
