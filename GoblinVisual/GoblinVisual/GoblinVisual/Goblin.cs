public class Goblin
{

    static int nextId = 0;
    int id;

    Emploi emploi;
    int salaire;

    int stress;
    Boolean greviste;
    Boolean occupe;

    Goblin collegue;
    Goblin superieur;

    Model model;
    Timer timer;


    public Goblin(Emploi emploi, int salaire, Goblin collegue, Goblin superieur)
    {
        id = nextId++;
        this.emploi = emploi;
        this.salaire = salaire; 
        stress = 0;
        greviste = false;
        this.collegue = collegue;
        this.superieur = superieur;
    }

    public void handleRequest(Requete requete)
    {
        if (requete.getType().Name != "Salaire")
        {
            //Si il ne peut pas la traiter
            if (occupe){
                stress += 5;
                passerCollegue(requete);
            //Si il peut la traiter 
            }else{
                //Si il doit la traiter
                if (requete.shouldHandle(this))
                {
                    timer = new Timer(requete.getTime(emploi));
                    timer.Elapsed += valider(requete);              //Quand il n'est plus occupe
                    timer.start();
                    occupe = true;
                }
                else
                {
                    passerSuperieur(requete);
                }
            }
        }
        else
        {
            model.ajouterCoffre(-1 * salaire);
            //Si tous les salaires de ce type d'emplois ont été traité
            if(collegue != model.getEmploye(0, 0)){
                passerCollegue(requete);
            }else{
                passerSuperieur(requete);
            }
        }
    }

    public void valider(Requete requete)
    {
        occupe = false;
        passerSuperieur(requete);
    }

    public void former()
    {
        if (emploi != Emploi.Chef)
        {
            stress /= 2;
            salaire *= 2;
            emploi.next();

            Goblin tmp = collegue;
            collegue = superieur;
            superieur = collegue.getSuperieur();
        }
    }

    public static int getNextId()
    {
        return nextId;
    }

    public static void setNextId(int nextId)
    {
        Goblin.nextId = nextId;
    }

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public Emploi getEmploi()
    {
        return emploi;
    }

    public void setEmploi(Emploi emploi)
    {
        this.emploi = emploi;
    }

    public int getSalaire()
    {
        return salaire;
    }

    public void setSalaire(int salaire)
    {
        this.salaire = salaire;
    }

    public int getStress()
    {
        return stress;
    }

    public void setStress(int stress)
    {
        this.stress = stress;
    }

    public Boolean getGreviste()
    {
        return greviste;
    }

    public void setGreviste(Boolean greviste)
    {
        this.greviste = greviste;
    }

    public Goblin getCollegue()
    {
        return collegue;
    }

    public void setCollegue(Goblin collegue)
    {
        this.collegue = collegue;
    }

    public Goblin getSuperieur()
    {
        return superieur;
    }

    public void setSuperieur(Goblin superieur)
    {
        this.superieur = superieur;
    }


    public void passerCollegue(Requete requete)
    {
        collegue.handleRequest(requete);
    }

    public void passerSuperieur(Requete requete)
    {
        superieur.handleRequest(requete);
    }



}