/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
using System.Collections.Generic;
using System;
using System.Timers;
using System.Collections;

namespace MODEL{
	public class Model
	{
	    private double argentCoffre = 3000;
	    private int nbRequetes = 0;

		private ArrayList employes = new ArrayList();
	    private List<Requete> requetes = new List<Requete>();

	    private Difficulte difficulte;
		private RequestsManager requestsManager;

		private Goblin currentGoblin;


	    public Model()
	    {
	        employes.Add(new List<Receptionniste>());
	        employes.Add(new List<Coffrier>());
	        employes.Add(new List<Tresorier>());
	        employes.Add(new List<Tamponeur>());
	        employes.Add(new List<Chef>());
			populateLists ();

	        difficulte = new Difficulte(5, 20, 5);
			requestsManager = new RequestsManager(requetes, currentGoblin, difficulte);

	    }

		public void populateLists(){
			currentGoblin = new Chef (this, Emploi.Chef, Salaire.getSalaire(0), null, null, difficulte);
			currentGoblin.setCollegue (currentGoblin);
			engager ();

			Tamponeur ta = new Tamponeur (this, Emploi.Tamponeur,  Salaire.getSalaire(1), null, currentGoblin, difficulte);
			ta.setCollegue (ta);
			engager (ta);

			Tresorier tr = new Tresorier (this, Emploi.Tresorier,  Salaire.getSalaire(2), null, ta, difficulte);
			tr.setCollegue (tr);
			engager(tr);

			Coffrier co = new Coffrier(this, Emploi.Coffrier,  Salaire.getSalaire(3), null, tr, difficulte);
			co.setCollegue (co);
			engager (co);

			Receptionniste re = new Receptionniste(this, Emploi.Receptionniste,  Salaire.getSalaire(4), null, co, difficulte);
			re.setCollegue (re);
			engager (re);
			currentGoblin = re;
		}

	    public void ajouterCoffre(double nbGold)
	    {
	        argentCoffre += nbGold;
	    }

	    public void braquage()
	    {
	        argentCoffre /= 2;
	        addStress(10);
	    }

		public void crashBoursier(){
			argentCoffre /= 3;
		}

		public void greve(){
			for (int i = 0; i < employes.Count; ++i)
			{
				List<Goblin> classe = (List<Goblin>) employes[i];
				for (int j = 1; j < classe.Count; ++j)
				{
					if(j % 2 == 0)
						classe[j].partirEnGreve();
				}
			}
		}

	    public double getSommeSalaires()
	    {
	        double somme = 0;
	        for (int i = 0; i < employes.Count; ++i)
	        {
				List<Goblin> classe = (List<Goblin>) employes[i];
				for (int j = 0; j < classe.Count; ++j)
	            {
					somme += classe[j].getSalaire();
	            }
	        }
	        return somme;
	    }

	    public void addStress(int prc)
	    {
	        for(int i = 0; i < employes.Count; ++i)
	        {
				List<Goblin> classe = (List<Goblin>) employes[i];
				for (int j = 0; j < classe.Count; ++j)
	            {
	                int stress = classe[j].getStress() + prc;
	                if(stress < 0)
	                {
	                    classe[j].setStress(0);
	                }else if(stress > 100)
	                {
	                    classe[j].setStress(100);
	                }
	                else
	                {
	                    classe[j].setStress(classe[j].getStress() - prc);
	                }
	            }
	        }
	    }

	    public void engager()
	    {
			List<Goblin> tmp = (List<Goblin>) employes[(int) currentGoblin.getEmploi()];
			tmp[tmp.Count - 1].setCollegue(currentGoblin);
			currentGoblin.setCollegue (tmp[0]);
			currentGoblin.setSuperieur(tmp[0].getSuperieur());
			tmp.Add(currentGoblin);
	    }

		public void engager(Goblin goblin)
		{
			List<Goblin> tmp = (List<Goblin>) employes[(int) goblin.getEmploi()];
			tmp[tmp.Count - 1].setCollegue(goblin);
			goblin.setCollegue (tmp[0]);
			goblin.setSuperieur(tmp[0].getSuperieur());
			tmp.Add(goblin);
		}

	    public bool virer()
	    {
			List<Goblin> collegues = (List<Goblin>) employes[(int)currentGoblin.getEmploi()];
			if (collegues.Count == 1)
	        {
				Console.WriteLine("Can't fire the last employe");
	            return false;
	        }
	        else {
				((List<Goblin>) employes[(int)currentGoblin.getEmploi()]).Remove(currentGoblin);
	            return true;
	        }
	    }

		public bool virer(Goblin goblin)
		{
			List<Goblin> collegues = (List<Goblin>) employes[(int)goblin.getEmploi()];
			if (collegues.Count == 1)
			{
				Console.WriteLine("Can't fire the last employe");
				return false;
			}
			else {
				((List<Goblin>) employes[(int)goblin.getEmploi()]).Remove(goblin);
				return true;
			}
		}

		public bool buyBonus(Bonus bonus)
		{
			if (bonus.getCost() > argentCoffre)
				return false;
			ajouterCoffre(bonus.getCost());
			return true;
			//prob traitement
		}

		public void selectionner(Goblin goblin)
		{
			currentGoblin = goblin;
		}

		public void generateAlEvent()
		{

		}
	}
}
