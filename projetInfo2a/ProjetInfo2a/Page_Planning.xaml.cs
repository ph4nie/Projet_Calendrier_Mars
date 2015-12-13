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
using System.Web;

namespace ProjetInfo2a
{
    /// <summary>
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Page_Planning : Page
    {
        private int _comptJours = 1;
        ClassMission _mission;
        //private Dictionary<int, ClassJour> _JoursAffiches = new Dictionary<int, ClassJour>();

        public Page_Planning(ClassMission mission)
        {
            _mission = mission;

            InitializeComponent();

            MessageBox.Show(_mission.getJourJ().ToString());

            for (int i = 1; i <= _mission.getDuree(); i++)
            {
                _mission.getPlanning()[i].autoSetStatut();
            }
        }

        private void AfficherJourJ(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            int nbJour = int.Parse(label.Content.ToString());
            ClassJour trouveJour = _mission.getPlanning()[nbJour];
            Page_Jour jour = new Page_Jour(trouveJour);
            this.NavigationService.Navigate(jour);

        }

        private void Jour_Loaded(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;

            //affiche le numéro du jour dans le Label
            label.Content = _comptJours;
            //affiche la couleur du label correspondant au statut du jour
            autoSetCouleur(label);

            _comptJours++;
        }

        // determine la couleur d'affichage d'un label de jour en fonction du statut
        private void autoSetCouleur(Label label)
        {
            int i = (int)label.Content;
            if (i <= 500)
            {
                // récupere l'instance de ClassJour correspondante dans le planning de la mission
                ClassJour dataJour = _mission.getPlanning()[i];

                string statut = dataJour.getStatut();
                string couleur;

                switch (statut)
                {
                    case "passé":
                        couleur = "#FF6C7A89"; //gris
                        break;
                    case "présent":
                        couleur = "#FF2ECC71"; //vert
                        break;
                    case "futur":
                        couleur = "#FF19B5FE"; //bleu
                        break;
                    default:
                        couleur = "#FF0000"; //rouge
                        break;
                }
                //attribue la couleur au fond
                label.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(couleur);
            }
        }

        //affiche les 21 prochains jours = rafraichir l'affichage des labels
        private void afficheNextPeriode(object sender, MouseButtonEventArgs e)
        {
            if (_comptJours <= 484)
                refreshLabels();
        }

        // affiche les 21 jours précédents
        private void affichePrevPeriode(object sender, MouseButtonEventArgs e)
        {
            if (_comptJours >= 42)
            {
                _comptJours -= 42;
                refreshLabels();
            }
        }

        private void refreshLabels()
        {
            for (int index = 1; index <= 21; index++)
            {
                // définit l'ID du Label
                string indexText = index.ToString();
                string labelId = "Jour_" + indexText;

                // trouve le Label porteur de l'ID
                Label label = (Label)FindName(labelId);

                // MàJ affichage Label
                label.Content = _comptJours++;
                autoSetCouleur(label);

                if (_comptJours > 501)
                    label.Visibility = Visibility.Hidden;
                else
                    label.Visibility = Visibility.Visible;
            }
        }
    }
}
