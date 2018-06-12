﻿using System.Timers;

namespace MODEL{
	public class Goblin
	{

	    static int nextId = 0;
	    protected int id;

		protected Emploi emploi;
		protected int salaire;

		protected int stress;
		protected bool greviste;
		protected bool occupe;

		protected Goblin collegue;
		protected Goblin superieur;

		protected Model model;
		protected Timer timer;


	    public Goblin(Model model, Emploi emploi, int salaire, Goblin collegue, Goblin superieur)
	    {
			this.model = model;
	        id = nextId++;
	        this.emploi = emploi;
	        this.salaire = salaire; 
	        stress = 0;
	        greviste = false;
	        this.collegue = collegue;
	        this.superieur = superieur;
	    }

	    public void partirEnGreve()
	    {
	        timer = new Timer(30);
	        timer.Elapsed += arreterGreve();
	        timer.Start;
	        model.supprimerMaillon(this);
	    }

	    public void arreterGreve()
	    {
	        stress = 0;
	        model.ajouterMaillon(this);
	    }

	    public void handleRequest(Requete requete)
	    {
	        //Si il ne peut pas la traiter
	        if (occupe){
	            stress += 5;
	            passerCollegue(requete);
	            if (stress >= 100)
	                partirEnGreve();

	        //Si il peut la traiter 
	        }else{
	            //Si il doit la traiter
	            if (requete.shouldHandle(this))
	            {
	                occupe = true;
	                timer = new Timer(3);
	                timer.Elapsed += valider(requete);              //Quand il n'est plus occupe
					timer.Start;
	            }
	            else
	            {
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
	            model.supprimerMaillon(this);
	            stress /= 2;
	            salaire *= 1.5;
	            emploi++;

	            collegue = superieur;
	            superieur = collegue.getSuperieur();
	            model.ajouterMaillon(this);
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

	    public bool getGreviste()
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
}