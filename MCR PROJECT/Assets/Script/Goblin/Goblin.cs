using System.Timers;

namespace MODEL{
	public class Goblin
	{

	    static int nextId = 0;
	    protected int id;

		protected Emploi emploi;
		protected double salaire;

		protected int stress;
		protected bool occupe;

		protected Goblin collegue;
		protected Goblin superieur;

		protected Model model;
		protected Timer timer;
		protected Difficulte difficulte;


		public Goblin(Model model, Emploi emploi, double salaire, Goblin collegue, Goblin superieur, Difficulte difficulte)
	    {
			this.model = model;
	        this.id = nextId++;
	        this.emploi = emploi;
	        this.salaire = salaire; 
	        this.stress = 0;
	        this.collegue = collegue;
	        this.superieur = superieur;
			this.difficulte = difficulte;
	    }

	    public void partirEnGreve()
	    {
	        timer = new Timer(30);
			timer.Elapsed += (sender, EventArgs) => arreterGreve();
			timer.Start();
	        model.virer(this);
	    }

	    public void arreterGreve()
	    {
	        stress = 0;
	        model.engager(this);
	    }

	    public void handleRequest(Requete requete)
	    {
	        //Si il ne peut pas la traiter
	        if (occupe){
				stress += difficulte.getStressPrc();
	            passerCollegue(requete);
				if (stress >= 100) {
					if (collegue == this) {
						model.setLoose();
					} else {
						partirEnGreve ();
					}
				}
	        //Si il peut la traiter 
	        }else{
	            //Si il doit la traiter
				if (requete.doitTraiter(this))
	            {
	                occupe = true;
	                timer = new Timer(3000);
					timer.Elapsed += (sender, EventArgs) => valider(requete);  //Quand il n'est plus occupe, appeler valider
					timer.Start();
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
	            model.virer(this);
	            stress /= 2;
				salaire = (Salaire.getSalaire((int) ++emploi));
	            collegue = superieur;
	            superieur = collegue.getSuperieur();
	            model.engager(this);
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

	    public double getSalaire()
	    {
	        return salaire;
	    }

	    public void setSalaire(double salaire)
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