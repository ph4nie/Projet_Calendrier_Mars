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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Page_Accueil : Page
    {
        public ClassMission _LAmission;

        public Page_Accueil()
        {
            _LAmission = new ClassMission();
            _LAmission.chargerInfo();
            _LAmission.initialisePlanning();

            InitializeComponent();
            MessageBox.Show(_LAmission.getJourneeDefaut().getActivites().Count().ToString(),"activité");
        }
    

    private void AfficherPlanning(object sender, RoutedEventArgs e)
    {
        Page_Planning planning = new Page_Planning(this._LAmission);
        this.NavigationService.Navigate(planning);
        /*Compte_Rendu cr = new Compte_Rendu();
        this.NavigationService.Navigate(cr);*/

    }
    private void AfficherExploration(object sender, RoutedEventArgs e)
    {
        Page_Exploration exploration = new Page_Exploration();
        this.NavigationService.Navigate(exploration);
    }

    private void AfficherRecherche(object sender, RoutedEventArgs e)
    {
        Page_Recherche recherche = new Page_Recherche();
        this.NavigationService.Navigate(recherche);
    }

}
}
