
public class Chef implements Goblin
{

	public Chef(Model model, Emploi emploi, double salaire, Goblin collegue, Goblin superieur, Difficulte difficulte) { super(model, emploi, salaire, collegue, superieur, difficulte)


	}

	public new void valider(PayementSalaire salaire)
	{
		model.ajouterCoffre(-1 * model.getSommeSalaires());
		occupe = false;
	}

	public new void passerSuperieur(Requete requete)
	{

	}
}