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
    /// Logique d'interaction pour Jour.xaml
    /// </summary>
    public partial class Page_Jour : Page
    {
        public ClassJour _jour;

        public Page_Jour(ClassJour jour)
        {
            InitializeComponent();

            _jour = jour;
            DataContext = _jour;

        }

        //recup les infos du jour cible pour les afficher
        private void ChargeAffichageJour(object sender, RoutedEventArgs e)
        {
            //affiche son numéro dans le titre
            Titre_Jour.Text = "Jour n°" + _jour.getNumero();
        }

        private void Consulter_CR(object sender, RoutedEventArgs e)
        {
            ClassCompteRendu cr = _jour.CompteRendu;
            Page_Compte_Rendu page_cr = new Page_Compte_Rendu(cr);
            this.NavigationService.Navigate(page_cr);
        }

        private void Voir_Activite(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            int ID = (int)cell.Content;
            ClassActivite act = _jour.Activites[ID];
            Page_Activite activite = new Page_Activite(act);
            this.NavigationService.Navigate(activite);
        }

        
        private void DataGridActivites_Loaded(object sender, RoutedEventArgs e)
        {
            //affiche son dictionaire d'activités dans le datagrid
            var grid = sender as DataGrid;

            //liaison entre les données et l'affichage 
            grid.SetBinding(DataGrid.ItemsSourceProperty, new Binding("Activites"));
        }
    }
}
