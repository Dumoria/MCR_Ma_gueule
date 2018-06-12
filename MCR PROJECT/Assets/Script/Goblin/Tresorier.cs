
namespace MODEL{
	public class Tresorier : Goblin
	{

	    Model model;

		public Tresorier(Model model, Emploi emploi, int salaire, Goblin collegue, Goblin superieur) : base(model, emploi, salaire, collegue, superieur)
	    {
	    }

	    public new void valider(Retrait retrait)
	    {
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
			model.ajouterCoffre(-1 * emprunt.getSomme());
			passerSuperieur(emprunt);
	        occupe = false;
	    }
	}
}