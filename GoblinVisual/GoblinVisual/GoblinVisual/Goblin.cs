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
        this.salaire = salaire;     //map
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
            if (occupe)
            {
                stress += 5;
                passerCollegue(requete);

                //Si il peut la traiter, lancer un timer
            }
            else
            {
                timer = new Timer(requete.getTime(emploi));
                timer.Elapsed += requeteTerminee(requete);  //Quand il n'est plus occupe
                timer.start();
                occupe = true;
            }
        }
        else
        {
            model.ajouterCoffre(-1 * salaire);
            passerCollegue(requete);
        }
    }

    /*
    Appel a cette methode en fin de timer (goblin occupe).
    On va alors chercher si la prochaine personne a qui
    passer la requete, si nec.
     */
    public void requeteTerminee(Requete requete)
    {

        occupe = false;
        int nextTask = requete.traiter(emploi);
        if (nextTask != -1)
        {
            if (nextTask == (int)emploi)
            {
                passerCollegue(requete);
            }
            else
            {
                passerSuperieur(requete);
            }
        }
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