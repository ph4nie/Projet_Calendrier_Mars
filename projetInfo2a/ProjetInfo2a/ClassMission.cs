using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace ProjetInfo2a
{
    public class ClassMission
    {
        private List<String> _activites;
        private int _nbAstraunautes;
        private List<String> _astronautes;
        private ClassLieu _lieu;
        private int _jourJ = -1;
        private DateTime _t0;
        private int _duree; //en nb de jours
        private ClassJour _journeeDefaut;
        private Dictionary<int, ClassJour> _planning;

        //constructeur par défaut, qui initialise la mission en chargeant les données
        public ClassMission()
        {
            _activites = new List<string>();
            _astronautes = new List<string>();
            _lieu = new ClassLieu();
            _planning = new Dictionary<int, ClassJour>();

            chargerInfo(); //désérialise infosGenerales.xml
            LoadPlanning(); //désérialise planning.xml 
         // initialisePlanning();  //sérialise un planning par défaut dans planning.xml
            autoSetJourJ(); //actualise le jour courant
            autoSetStatuts(); //actualise le statut de chaq jour en fonction du jour courant
        }

        // accesseurs
        public List<String> getActivites()
        {
            return _activites;
        }

        public int getJourJ()
        {
            return _jourJ;
        }

        public DateTime getT0()
        {
            return _t0;
        }

        public int getDuree()
        {
            return _duree;
        }

        public void setDuree(int nbJours)
        {
            _duree = nbJours;
        }
        public Dictionary<int, ClassJour> getPlanning()
        {
            return _planning;
        }
        public ClassJour getJourneeDefaut()
        {
            return _journeeDefaut;
        }

        // recupère le numéro du jour Martien courant à partir de la date Terrienne
        public void autoSetJourJ()
        {
            TimeSpan tpsEcoule = DateTime.Today - _t0;
            double tpsEcouleHeures = tpsEcoule.TotalHours;
            _jourJ = (int)(1 + tpsEcouleHeures / 24.4);
        }
        //actualise le statut de chaq jour en fonction de la date courante
        public void autoSetStatuts()
        {
            for (int i = 1; i <= _duree; i++)
            {
                _planning[i].autoSetStatut();
            }
        }

        // désérialisation globale qui appelle les methodes de chaque champ de Mission
        public void chargerInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("../../Data/infosGenerales.xml");
            }
            catch
            {
                string message = "Le fichier XML de sauvegarde n'a pas été trouvé dans le répertoire.";
                MessageBox.Show(message);
                return;
            }

            // désérialisations
            load_mission(xmlDoc);
            load_activites(xmlDoc);
            load_lieu(xmlDoc);
            load_astronautes(xmlDoc);
            load_journeeDefaut(xmlDoc);

        }

        // désérialisation de <mission>
        private void load_mission(XmlDocument doc)
        {
            _lieu = new ClassLieu();
            // on crée un noeud pour la balise mission
            XmlNode node = doc.SelectSingleNode("/informations/mission");

            //on recupere son t0 dans l'attribut de la balise du .xml
            XmlAttribute xml_attr = node.Attributes["t0"];

            // on affecte le champ t0 de la Mission avec l'attribut qu'on vient de récup
            _t0 = DateTime.Parse(xml_attr.Value);

            //idem pour le champ duree
            xml_attr = node.Attributes["duree"];
            _duree = int.Parse(xml_attr.Value);
        }

        // désérialisation de <lieu>
        private void load_lieu(XmlDocument doc)
        {
            _lieu = new ClassLieu();
            // on crée un noeud pour la balise lieu
            XmlNode node = doc.SelectSingleNode("/informations/lieu");

            //on recupere son nom dans l'attribut de la balise du .xml
            XmlAttribute xml_attr = node.Attributes["nom"];

            // on affecte la propriété _lieu._nom avec l'attribut qu'on vient de récup
            _lieu.setNom(xml_attr.Value);

            //idem pour la balise carte de lieu
            node = doc.SelectSingleNode("/informations/lieu/carte");
            xml_attr = node.Attributes["image"];
            _lieu.setCarte(xml_attr.Value);

            xml_attr = node.Attributes["echelle"];
            _lieu.setEchelle(int.Parse(xml_attr.Value));

            //idem pour la balise position de lieu
            node = doc.SelectSingleNode("/informations/lieu/position");
            xml_attr = node.Attributes["longitude"];
            XmlAttribute xml_attr2 = node.Attributes["latitude"];
            _lieu.setPosition(double.Parse(xml_attr.Value), double.Parse(xml_attr2.Value));
        }

        // désérialisation de <activites>
        private void load_activites(XmlDocument doc)
        {
            _activites = new List<String>();
            XmlNodeList nl = doc.SelectNodes("/informations/activites/activite");
            foreach (XmlNode node in nl) // pour chaque activite de activites
            {
                //on recupere sa categorie dans l'attribut de la balise du .xml
                XmlAttribute xml_attr = node.Attributes["categorie"];
                //on instancie un string contenant avec l'attribut qu'on vient de récup
                String activite = xml_attr.Value;

                xml_attr = node.Attributes["sous-categorie"];
                if (xml_attr != null)
                    activite += " / " + xml_attr.Value;

                //idem pour l'attribut nom 
                xml_attr = node.Attributes["nom"];
                activite += " / " + xml_attr.Value;

                // on ajoute l'activité à la liste d'activités de la mission
                _activites.Add(activite);
            }
        }

        //désérialisation de <astonautes>
        private void load_astronautes(XmlDocument doc)
        {
            XmlNode n = doc.SelectSingleNode("/informations/astronautes/effectif");
            XmlAttribute xml_attr = n.Attributes["nb"];
            _nbAstraunautes = int.Parse(xml_attr.Value);

            _astronautes = new List<String>();
            XmlNodeList nl = doc.SelectNodes("/informations/astronautes/astronaute");
            foreach (XmlNode node in nl)
            {
                String astronaute;
                xml_attr = node.Attributes["nom"];
                astronaute = xml_attr.Value;

                _astronautes.Add(astronaute);
            }
        }

        // désérialisation de journeeDefaut
        private void load_journeeDefaut(XmlDocument doc)
        {
            _journeeDefaut = new ClassJour(this);

            XmlNodeList nl = doc.SelectNodes("/informations/journeeDefaut/activite");
            foreach (XmlNode node in nl)
            {
                ClassActivite activite = new ClassActivite();
                XmlAttribute xml_attr = node.Attributes["categorie"];
                activite.Categorie = xml_attr.Value;
                xml_attr = node.Attributes["nom"];
                activite.Categorie = activite.Categorie + " / " + xml_attr.Value;

                xml_attr = node.Attributes["hdebut"];
                activite.HeureDebut = double.Parse(xml_attr.Value);
                xml_attr = node.Attributes["hfin"];
                activite.HeureFin = double.Parse(xml_attr.Value);

                _journeeDefaut.ajouterActivite(activite);
            }
        }

        //désérialise planning.xml
        public void LoadPlanning()
        {
            XmlDocument xmlDoc = new XmlDocument();
            string path = "../../Data/planning.xml";
            try
            {
                xmlDoc.Load(path);
            }
            catch
            {
                string message = "Le fichier XML de sauvegarde n'a pas été trouvé dans le répertoire.";
                MessageBox.Show(message);
                return;
            }
            //récup tous les jours du planning
            XmlNodeList listJours = xmlDoc.SelectNodes("/Planning/Jour");


            //désérialise les 500 jours depuis planning.xml
            foreach (XmlNode nodeJour in listJours)
            {
                ClassJour jour = new ClassJour(this);

                XmlAttribute numJour = nodeJour.Attributes["numero"];
                int index = int.Parse(numJour.Value);

                //récup toutes les activites du jour correspondant à l'index courant
                XmlNodeList listActs = xmlDoc.SelectNodes("/Planning/Jour[@numero='" + index + "']/Activite");

                foreach (XmlNode nodeAct in listActs)
                {
                    ClassActivite activite = new ClassActivite();

                    //récupère l'attribut categorie
                    XmlAttribute xml_attr = nodeAct.Attributes["categorie"];
                    //stocke sa valeur dans la propriété Categorie de l'objet
                    activite.Categorie = xml_attr.Value;

                    //idem pour le reste des attributs/propriétés
                    xml_attr = nodeAct.Attributes["hDebut"];
                    activite.HeureDebut = double.Parse(xml_attr.Value);
                    xml_attr = nodeAct.Attributes["hFin"];
                    activite.HeureFin = double.Parse(xml_attr.Value);
                    xml_attr = nodeAct.Attributes["astronautes"];
                    activite.Astronautes.Add(xml_attr.Value);    //decouper la chaine en substring si plusieurs astro
                    xml_attr = nodeAct.Attributes["lieu"];
                    activite.Lieu.setNom(xml_attr.Value);
                    xml_attr = nodeAct.Attributes["descriptif"];
                    activite.Descriptif = xml_attr.Value;
                    xml_attr = nodeAct.Attributes["sortieExt"];
                    if (xml_attr.Value == "true")
                        activite.SortieExt = true;
                    else
                        activite.SortieExt = false;

                    activite.Date = jour; //le jour qu'on est en train de créer


                    jour.ajouterActivite(activite);
                }

                _planning.Add(index, jour);
            }
        }


        // remplissage du planning par défaut : 500 journées initialisées par défaut
        // appelé une fois, pour sérialisation de planning.xml , puis inutilisé
        public void initialisePlanning()
        {
            XmlDocument xmlDocOut = new XmlDocument();
            string path = "../../Data/planning.xml";
            try
            {
                xmlDocOut.Load(path);
            }
            catch
            {
                string message = "Le fichier XML de sauvegarde n'a pas été trouvé dans le répertoire.";
                MessageBox.Show(message);
                return;
            }
            //recupère la racine
            XmlElement root = xmlDocOut.DocumentElement;

            for (int i = 1; i <= _duree; i++)
            {
                //crée un jour
                XmlElement jour = xmlDocOut.CreateElement("Jour");
                jour.SetAttribute("numero", i.ToString());

                //rempli sa liste Activites avec celles par défaut
                foreach (ClassActivite act in _journeeDefaut.Activites)
                {
                    //rempli les attributs connus
                    XmlElement activite = xmlDocOut.CreateElement("Activite");
                    activite.SetAttribute("hDebut", act.HeureDebut.ToString());
                    activite.SetAttribute("hFin", act.HeureFin.ToString());
                    activite.SetAttribute("categorie", act.Categorie);
                    
                    //crée des attribus vides pour les champs non définis par défaut
                    activite.SetAttribute("astronautes", "");
                    activite.SetAttribute("lieu", "");
                    activite.SetAttribute("descriptif", "");
                    activite.SetAttribute("sortieExt", "");

                    jour.AppendChild(activite);
                }

                root.AppendChild(jour);

                xmlDocOut.Save(path);

            }
        }
    }
}
