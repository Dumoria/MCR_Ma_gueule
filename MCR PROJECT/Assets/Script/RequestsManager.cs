using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using UnityEngine;

namespace MODEL{
    public class RequestsManager
    {
		private Model model;
		private int nbTotRequetes = 0;
		private List<Requete> requetes;
		private Goblin firstRecep;

		private System.Random random = new System.Random();
		private Difficulte difficulte;
		private Timer flotRequetes;

		public RequestsManager(Model model, List<Requete> requetes, Goblin firstRecep, Difficulte difficulte){
			this.model = model;
			this.requetes = requetes;
			this.firstRecep = firstRecep;
			this.difficulte = difficulte;
			start ();
		}

		public void start(){
			this.update ();
		}

		public int generateRandomAmount(){
			return random.Next () % 2000;
		}

		public void generateAlEvent()
		{
			int typeEv = random.Next() % 6;	//Une chance sur deux d'avoir un evenement aleatoire
			switch (typeEv)
			{
			case 0:
				model.braquage();
				break;
			case 1:
				model.crashBoursier();
				break;
			case 2:
				model.greve ();
				break;
			default:
				break;
			}

		}
			
		public void update()
		{

			requetes.Add(generateARequest());
			firstRecep.handleRequest(requetes[0]);
			requetes.RemoveAt(0);

			if(nbTotRequetes % difficulte.getNbRequetePourEvAl() == 0)
				generateAlEvent ();
			if (nbTotRequetes % 75 == 0) 
				difficulte.niveauSuperieur ();
			

			if (!model.getLoose()) {
				flotRequetes = new Timer (difficulte.getDebitRequetes ());
				flotRequetes.Elapsed += (sender, EventArgs) => start ();
				flotRequetes.Start ();
			}

		}

		public Requete generateARequest()
		{
			int typeRequete = random.Next() % 9;
			Requete requete;
			++nbTotRequetes;

			switch (typeRequete)
			{
			case 0:
				return new CertificatFortune(generateRandomAmount());
				break;
			case 1:
				return new Retrait(generateRandomAmount());
				break;
			case 2:
				return new Depot(generateRandomAmount());
				break;
			case 3:
				return new Remboursement(generateRandomAmount());
				break;
			case 4:
				return new Emprunt(generateRandomAmount());
				break;
			case 5:
				return new PayementSalaire();
				break;
			case 6:
				return new MiroirDoubleSens();
				break;
			case 7:
				return new OuvrirCompte();
				break;
			case 8:
				return new TraiterBeuglantes();
				break;
			default:
				return null;

			}

		}
    }
}
