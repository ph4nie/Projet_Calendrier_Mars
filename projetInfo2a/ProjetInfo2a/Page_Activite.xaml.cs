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
using System.Xml;

namespace ProjetInfo2a
{
    /// <summary>
    /// Logique d'interaction pour Activite.xaml
    /// </summary>
    public partial class Page_Activite : Page
    {
        ClassActivite _activite;

        public Page_Activite(ClassActivite activite)
        {
            InitializeComponent();

            _activite = activite;

            DataContext = _activite; //référentiel pour Binding
        }

        private void Bouton_Carte(object sender, RoutedEventArgs e)
        {
            Page_Exploration exploration = new Page_Exploration();
            this.NavigationService.Navigate(exploration);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Case_Texte_HD.SetBinding(TextBox.TextProperty, new Binding("HeureDebut"));
            Case_Texte_HF.SetBinding(TextBox.TextProperty, new Binding("HeureFin"));
           // Case_Texte_Astronautes.SetBinding(TextBox.TextProperty, new Binding("Astronautes"));
            Case_Texte_Position.SetBinding(TextBox.TextProperty, new Binding("Lieu"));
            Case_Texte_Descriptif.SetBinding(TextBox.TextProperty, new Binding("Descriptif"));

           
        }

        private void Enregistrer_Activite(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDocOut = new XmlDocument();
            string path = "../../Data/planning.xml";
            try
            {
                xmlDocOut.Load(path);
            }
            catch
            {
                string message = "Le fichier XML de sauvegarde n'a pas été trouvé dans le répertoire.";
                MessageBox.Show(message);
                return;
            }

            //recupère le jour concerné
            XmlNode jourJ = xmlDocOut.SelectSingleNode("/Planning/Jour[@numero='" + _activite.Date + "']");

            //récupère le creneau correspondant à l'activité s'il existe dans le planning.xml
            XmlNode exAct = xmlDocOut.SelectSingleNode("/Planning/Jour[@numero='" + _activite.Date
                + "']/Activite[@hDebut='" + _activite.HeureDebut + "']");
            if (exAct != null)
            {
                //modif la balise existante
                exAct.Attributes["hDebut"].Value = Case_Texte_HD.Text;
                exAct.Attributes["hFin"].Value = Case_Texte_HF.Text;
                exAct.Attributes["categorie"].Value = Case_Selection_Categorie.SelectedItem.ToString();
                exAct.Attributes["astronautes"].Value = Case_Texte_Astronautes.Text;
                exAct.Attributes["lieu"].Value = Case_Texte_Position.Text;
                exAct.Attributes["descriptif"].Value = Case_Texte_Descriptif.Text;
                exAct.Attributes["sortieExt"].Value = _activite.SortieExt.ToString();
            }
            else
            {
                //crée une activité
                XmlElement act = xmlDocOut.CreateElement("Activite");
                act.SetAttribute("hDebut", Case_Texte_HD.Text);
                act.SetAttribute("hFin", Case_Texte_HF.Text);
                act.SetAttribute("categorie", Case_Selection_Categorie.SelectedItem.ToString());
                act.SetAttribute("astronautes", Case_Texte_Astronautes.Text);
                act.SetAttribute("lieu", Case_Texte_Position.Text);
                act.SetAttribute("descriptif", Case_Texte_Descriptif.Text);


                //insère la balise Activite remplie dans planning.xml
                jourJ.AppendChild(act);
            }

            xmlDocOut.Save(path);

            //retourne sur la page du jour
            Page_Jour jour = new Page_Jour(_activite.Date);
            this.NavigationService.Navigate(jour);
        }

        private void Case_Selection_Categorie_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmbx = sender as ComboBox;
            
            cmbx.SetBinding(ComboBox.ItemsSourceProperty, new Binding("categories"));
            
        }
    }
}

