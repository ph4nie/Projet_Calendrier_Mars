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
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Page_Planning : Page
    {
        private int _comptJours = 1; // incrémenté par Next / décrementé par previous (-/+21)
        ClassMission _mission;

        public Page_Planning(ClassMission mission)
        {
            _mission = mission;

            InitializeComponent();

        }

        private void AfficherJourJ(object sender, MouseButtonEventArgs e)
        {
            Label labelJour = sender as Label;
            int nbJour = int.Parse(labelJour.Content.ToString());
            ClassJour trouveJour = _mission.getPlanning()[nbJour];
            Page_Jour jour = new Page_Jour(trouveJour);
            this.NavigationService.Navigate(jour);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //
        }
        private void Jour_Loaded(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            label.Content = _comptJours++;
        }

        private void afficheNextPeriode(object sender, MouseButtonEventArgs e)
        {
            // "rafraichir l'affichage des labels"
            MessageBox.Show(_comptJours.ToString(), "Compteur de jours");
            //GridPlanning.InvalidateVisual();
            foreach (Label label in Grid.)
        }

        private void affichePrevPeriode(object sender, MouseButtonEventArgs e)
        {
            if (_comptJours >= 42)
            {
                _comptJours -= 42;
                // "rafraichir l'affichage des labels"
            }
        }
    }
}
