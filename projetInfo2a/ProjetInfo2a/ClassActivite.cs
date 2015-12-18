using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfo2a
{
    public class ClassActivite
    {
        //propriétés publiques pour etre affichable dans l'appli avec Binding
        public double HeureDebut
        {
            get; set;
        }
        public double HeureFin
        {
            get; set;
        }
        public List<string> Astronautes
        {
            get; set;
        }

        public string Descriptif
        {
            get; set;
        }
        public string Categorie
        {
            get; set;
        }
        public bool SortieExt
        {
            get; set;
        }
        public ClassLieu Lieu
        {
            get; set;
        }
        public ClassJour Date
        {
            get; set;
        }

        public ClassActivite()
        {
            Astronautes = new List<string>();
            Lieu = new ClassLieu();
        }


        public void ajoutAstronaute(string astronaute)
        {
            Astronautes.Add(astronaute);
        }

        public void supprAstronaute(string astronaute)
        {
            Astronautes.Remove(astronaute);
        }
    }
}
