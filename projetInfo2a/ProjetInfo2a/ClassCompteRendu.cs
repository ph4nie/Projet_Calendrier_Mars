using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfo2a
{
    public class ClassCompteRendu
    {
        private static int _nbCaractMax = 1000;

        public string _titre
        {
            get; set;
        }
        public string _contenu
        {
            get; set;
        }
        
        public ClassJour _date;

        public ClassCompteRendu(ClassJour date)
        {
            _date = date;
            _titre = "Compte-Rendu du Jour " + _date;
        }

        public void setDate(ClassJour newDate)
        {
            _date = newDate;
        }
        public ClassJour getDate()
        {
            return _date;
        }
    }
}
