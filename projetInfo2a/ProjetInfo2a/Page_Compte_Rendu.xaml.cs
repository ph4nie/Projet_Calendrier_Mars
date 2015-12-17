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
            _cr = cr;

            InitializeComponent();
        }

        private void Modifier_CR(object sender, RoutedEventArgs e)
        {
            Bouton_Modifier_CR.Visibility = Visibility.Hidden;
            Bouton_Enregistrer_CR.Visibility = Visibility.Visible;
            Texte_1000_caract.Visibility = Visibility.Visible;
            Case_Texte_CR.Visibility = Visibility.Visible;
            Case_Texte_CR_MAJ.Visibility = Visibility.Hidden;
        }

        private void Enregistrer_CR(object sender, RoutedEventArgs e)
        {
            Bouton_Enregistrer_CR.Visibility = Visibility.Hidden;
            Texte_1000_caract.Visibility = Visibility.Hidden;
            Case_Texte_CR.Visibility = Visibility.Hidden;
            Bouton_Modifier_CR.Visibility = Visibility.Visible;
            Case_Texte_CR_MAJ.Visibility = Visibility.Visible;

            //sérialiser dans le planning.xml
        }

        // Afiche le titre du CR
        private void Titre_CR_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbk = sender as TextBlock;

            //titre du CR s'il existe
            string titre = _cr.getTitre();
            if (titre != null)
                tbk.Text = titre;
            //sinon titre par défaut
            else
                tbk.Text = "Compte-Rendu du Jour " + _cr.getDate().ToString();
        }

        private void ContenuCR_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tbk = sender as TextBlock;

            //récup contenu s'il existe
            string contenu = _cr.getContenu();
            if (contenu != null)
                tbk.Text = contenu;
            //sinon message par défaut
            else
                tbk.Text = "Aucun compte-rendu n'a été rédigé pour ce jour";
        }
    }
}
