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
    /// Logique d'interaction pour Compte_Rendu.xaml
    /// </summary>
    public partial class Page_Compte_Rendu : Page
    {
        ClassCompteRendu _cr;

        public Page_Compte_Rendu(ClassCompteRendu cr)
        {
            InitializeComponent();

            _cr = cr;
            DataContext = _cr; //référentiel pour Binding
        }

        private void Modifier_CR(object sender, RoutedEventArgs e)
        {
            Bouton_Modifier_CR.Visibility = Visibility.Hidden;
            Bouton_Enregistrer_CR.Visibility = Visibility.Visible;
            Texte_1000_caract.Visibility = Visibility.Visible;
            Case_Texte_CR_Modif.Visibility = Visibility.Visible;
            Case_Texte_CR.Visibility = Visibility.Hidden;
            Titre_CR_Modif.Visibility = Visibility.Visible;

            Case_Texte_CR_Modif.SetBinding(TextBox.TextProperty, new Binding("_contenu"));
            Titre_CR_Modif.SetBinding(TextBox.TextProperty, new Binding("_titre"));
        }

        private void Enregistrer_CR(object sender, RoutedEventArgs e)
        {
            Bouton_Enregistrer_CR.Visibility = Visibility.Hidden;
            Texte_1000_caract.Visibility = Visibility.Hidden;
            Case_Texte_CR_Modif.Visibility = Visibility.Hidden;
            Titre_CR_Modif.Visibility = Visibility.Hidden;
            Bouton_Modifier_CR.Visibility = Visibility.Visible;
            Case_Texte_CR.Visibility = Visibility.Visible;

            Case_Texte_CR.SetBinding(TextBlock.TextProperty, new Binding("_contenu"));
            Titre_CR.SetBinding(TextBlock.TextProperty, new Binding("_titre"));

            //sérialise les modification du CR dans planning.xml
            saveCR();
        }

        // Afiche le titre du CR
        private void Titre_CR_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbk = sender as TextBlock;

            //lie le textblock à la propriété _titre
            tbk.SetBinding(TextBlock.TextProperty, new Binding("_titre"));
        }

        private void ContenuCR_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbk = sender as TextBlock;

            //lie le textblock à _contenu
            tbk.SetBinding(TextBlock.TextProperty, new Binding("_contenu"));

        }

        //sérialise les modification du CR dans planning.xml
        private void saveCR()
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
            XmlNode jourJ = xmlDocOut.SelectSingleNode("/Planning/Jour[@numero='" + _cr._date + "']");

            //récupère le CR s'il existe dans le planning.xml
            XmlNode exCR = xmlDocOut.SelectSingleNode("/Planning/Jour[@numero='" + _cr._date + "']/CompteRendu");
            if (exCR != null)
            {
                //modif la balise existante
                exCR.Attributes["titre"].Value = Titre_CR_Modif.Text;
                exCR.InnerText = Case_Texte_CR_Modif.Text;
            }
            else
            {
                //crée un CR
                XmlElement cr = xmlDocOut.CreateElement("CompteRendu");
                cr.SetAttribute("titre", Titre_CR_Modif.Text);
                cr.InnerText = Case_Texte_CR_Modif.Text;

                //insère la balise CompteRendu remplie dans planning.xml
                jourJ.AppendChild(cr);
            }

            xmlDocOut.Save(path);
        }


    }
}
