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
            InitializeComponent();

            _cr = cr;
            DataContext = _cr; //référentiel pour Binding
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

            Case_Texte_CR_MAJ.SetBinding(TextBox.TextProperty, new Binding("_contenu"));

            //sérialiser dans le planning.xml
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
    }
}
