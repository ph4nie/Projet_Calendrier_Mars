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
        public List<ClassActivite> _activites;
        public ClassCompteRendu _compteRendu;
        public ClassMission _mission;


        public ClassJour(ClassMission laMission)
        {
            _numero = compteurJours++;  //laMission._journeeDefaut sera le jour 0 (premier objet instancié)
                                        // les prochains jours auront le num correspondant à leur ID

            _statut = "futur"; // obligatoire pour remplissage journée défaut
            _mission = laMission;
            _activites = new List<ClassActivite>();
        }

        public bool getSortieExte()
        {
            // return true ssi une des activités de _activites return true aussi
            foreach (ClassActivite act in _activites)
            {
                if (act.getSortieExt())
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

        public void setCR(ClassCompteRendu CR)
        {
            _compteRendu = CR;
        }

        public ClassCompteRendu getCR()
        {
            return _compteRendu;
        }
        public List<ClassActivite> getActivites()
        {
            return _activites;
        }
        public void setActivites(List<ClassActivite> newActivites)
        {
            _activites = newActivites;
        }

        public ClassMission getMission()
        {
            return _mission;
        }

        // insere une activité au dico et lui donne pr clef son couple hDebut, hFin
        public void ajouterActivite(ClassActivite act)
        {
            if (this.getStatut() == "futur")
            {
                _activites.Add(act);
            }
        }

        public void supprActivite(ClassActivite act)
        {
            if (this.getStatut() == "futur")
            {
                //remove <key,value> where key==creneau
                _activites.Remove(act);
            }
        }
        /*
        public void modifAcitivite(ClassActivite newAct)
        {
            if (this.getStatut() == "futur" && newAct.getHeureDeb() == crenau[0]
                && newAct.getHeureFin() == crenau[1])
            {
                _activites.Remove(crenau);
                ajouterActivite(newAct);
            }
        }
        */

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
    }
}
