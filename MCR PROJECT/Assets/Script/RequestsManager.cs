using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace MODEL{
    public class RequestsManager
    {
		private int nbTotRequetes = 0;
		private List<Requete> requetes;
		private Goblin firstRecep;

		private Random random = new Random();
		private Difficulte difficulte;
		private Timer flotRequetes;

		public RequestsManager(List<Requete> requetes, Goblin firstRecep, Difficulte difficulte){
			this.requetes = requetes;
			this.firstRecep = firstRecep;
			this.difficulte = difficulte;
		}

		public int generateRandomAmount(){
			return random.Next () % 2500;
		}

		public void generateAlEvent()
		{
			int typeEv = random.Next() % 6;	//Une chance sur deux d'avoir un evenement aleatoire
			switch (typeEv)
			{
			case 0:
				Model.braquage();
				break;
			case 1:
				Model.crashBoursier();
				break;
			case 2:
				Model.greve ();
				break;
			default:
				break;
			}

		}
			
		public void start()
		{

			requetes.Add(generateARequest());
			firstRecep.handleRequest(requetes[0]);
			requetes.RemoveAt(0);

			if(nbTotRequetes % difficulte.getNbRequetePourEvAl == 0)
				generateAlEvent ();
			if (nbTotRequetes % 75 == 0) 
				difficulte.niveauSuperieur ();
			

			if (!Model.getLoose()) {
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
