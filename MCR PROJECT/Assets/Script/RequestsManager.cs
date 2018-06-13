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
			
		public void start()
		{

			requetes.Add(generateARequest());
			firstRecep.handleRequest(requetes[0]);
			requetes.RemoveAt(0);

			if (nbTotRequetes % 50 == 0)
				difficulte.niveauSuperieur();

			flotRequetes = new Timer(difficulte.getDebitRequetes());
			flotRequetes.Elapsed += (sender, EventArgs) => start();
			flotRequetes.Start();

		}

		public Requete generateARequest()
		{
			int typeRequete = random.Next() % 9;
			Requete requete;
			++nbTotRequetes;

			switch (typeRequete)
			{
			case 0:
				//requete = new CertificatFortune();
				break;
			case 1:
				//requete = new Retrait();
				break;
			case 2:
				//requete = new Depot();
				break;
			case 3:
				//requete = new Remboursement();
				break;
			case 4:
				//requete = new Emprunt();
				break;
			case 5:
				requete = new PayementSalaire();
				break;
			case 6:
				requete = new MiroirDoubleSens();
				break;
			case 7:
				requete = new OuvrirCompte();
				break;
			case 8:
				requete = new TraiterBeuglantes();
				break;
			default:
				break;

			}
			return requete;

		}
    }
}
