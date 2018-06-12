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

	    /**
	     * nombre de classe hierarchique dans la banque
	     */
	    private double argentCoffre = 3000;
	    private int nbRequetes = 0;

		private ArrayList employes = new ArrayList();
	    private List<Requete> requetes = new List<Requete>();

	    private Difficulte difficulte;
		private Goblin currentGolbin;

	    public Model()
	    {
	        employes.Add(new List<Receptionniste>());
	        employes.Add(new List<Coffrier>());
	        employes.Add(new List<Tresorier>());
	        employes.Add(new List<Tamponeur>());
	        employes.Add(new List<Chef>());

	        difficulte = new Difficulte(5, 20, 5);
			//request manager
			//Goblin

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

	    public void engager(Goblin goblin)
	    {
			List<Goblin> tmp = (List<Goblin>) employes[(int)goblin.getEmploi()];
	        tmp[tmp.Count - 1].setCollegue(goblin);
	        goblin.setSuperieur(tmp[0].getSuperieur());
	        tmp.Add(goblin);
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
			currentGolbin = goblin;
		}

		public void generateAlEvent()
		{

		}
	}
}
