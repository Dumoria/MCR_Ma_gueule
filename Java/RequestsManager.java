import java.util.Random;
import java.util.Timer;

public class RequestsManager
{
	private Model model;
	private int nbTotRequetes = 0;
	private List<Requete> requetes;
	private Goblin firstRecep;

	private Random random = new Random();
	private Difficulte difficulte;
	private Timer flotRequetes;

	public RequestsManager(Model model, List<Requete> requetes, Goblin firstRecep, Difficulte difficulte){
		this.model = model;
		this.requetes = requetes;
		this.firstRecep = firstRecep;
		this.difficulte = difficulte;
	}

	public int generateRandomAmount(){
		return random.nextInt(2000);
	}

	public void generateAlEvent()
	{
		int typeEv = random.nextInt(6);	//Une chance sur deux d'avoir un evenement aleatoire
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

	public void start()
	{
		while(!model.getLoose()){
			requetes.Add(generateARequest());
			firstRecep.handleRequest(requetes[0]);
			requetes.RemoveAt(0);

			if(nbTotRequetes % difficulte.getNbRequetePourEvAl() == 0)
				generateAlEvent ();
			if (nbTotRequetes % 75 == 0)
				difficulte.niveauSuperieur ();
			try {
				wait(difficulte.getDebitRequetes());
			}
			catch (Exception e ){
				//oups
			}
		}

	}

	public Requete generateARequest()
	{
		int typeRequete = random.nextInt(9);
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

