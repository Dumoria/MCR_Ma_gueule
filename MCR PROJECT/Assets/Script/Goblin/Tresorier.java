
namespace MODEL{
	public class Tresorier : Goblin
	{

	    Model model;

		public Tresorier(Model model, Emploi emploi, double salaire, Goblin collegue, Goblin superieur, Difficulte difficulte) : base(model, emploi, salaire, collegue, superieur, difficulte)
	    {
	    }

	    public new void valider(Retrait retrait)
	    {
			if (model.getArgentCoffre () - retrait.getSomme () < 0)
				model.setLoose();
			model.ajouterCoffre(-1 * retrait.getSomme());
			passerSuperieur(retrait);
	        occupe = false;
	    }

	    public new void valider(Depot depot)
	    {
			model.ajouterCoffre(depot.getSomme());
			passerSuperieur(depot);
	        occupe = false;
	    }

	    public new void valider(Remboursement remboursement)
	    {
			model.ajouterCoffre(remboursement.getSomme());
			passerSuperieur(remboursement);
	        occupe = false;
	    }

	    public new void valider(Emprunt emprunt)
	    {
			if (model.getArgentCoffre () - emprunt.getSomme () < 0)
				return;
			model.ajouterCoffre(-1 * emprunt.getSomme());
			passerSuperieur(emprunt);
	        occupe = false;
	    }
	}
}