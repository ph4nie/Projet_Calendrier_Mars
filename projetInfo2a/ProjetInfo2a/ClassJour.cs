using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfo2a
{
    public class ClassJour
    {
        private static int compteurJours = 0;
        private int _numero;
        private string _statut; // passé/prst/futur
        public List<ClassActivite> Activites
        {
            get; set;            //propriété public pour etre accessible à l'affichage avec le Binding
        }  
        public ClassCompteRendu CompteRendu
        {
            get; set;            
        }
        public ClassMission _mission;
 
        public ClassJour(ClassMission laMission)
        {
            _numero = compteurJours++;  //laMission._journeeDefaut sera le jour 0 (premier objet instancié)
                                        // les prochains jours auront le num correspondant à leur ID

            _statut = "futur"; // obligatoire pour remplissage journée défaut
            _mission = laMission;
            Activites = new List<ClassActivite>();
            CompteRendu = new ClassCompteRendu();
        }

        public bool getSortieExte()
        {
            // return true ssi une des activités de Activites return true aussi
            foreach (ClassActivite act in Activites)
            {
                if (act.SortieExt)
                    return true;
            }
            return false;
        }

        public int getNumero()
        {
            return _numero;
        }

        public void setNumero(int newNum)
        {
            _numero = newNum;
        }
        public void setStatut(String newStatut)
        {
            _statut = newStatut;
        }

        public String getStatut()
        {
            return _statut;
        }

        public ClassMission getMission()
        {
            return _mission;
        }

        // insere une activité a la liste d'act du jour
        public void ajouterActivite(ClassActivite act)
        {
            if (this.getStatut() == "futur")
            {
                Activites.Add(act);
            }
        }

        public void supprActivite(ClassActivite act)
        {
            if (this.getStatut() == "futur")
            {
                Activites.Remove(act);
            }
        }

        public void autoSetStatut()
        {
            int diff = _numero - _mission.getJourJ();
            Console.WriteLine("jour J : " + _mission.getJourJ()
                + "\nnumero : " + _numero
                + "\ndifférence = " + diff);

            switch (Math.Sign(diff))
            {
                case -1:
                    setStatut("passé");
                    break;
                case 0:
                    setStatut("présent");
                    break;
                case 1:
                    setStatut("futur");
                    break;
            }

        }
        
        public override string ToString()
        {
            return _numero.ToString();
        }
        
    }
}
