namespace MODEL{
	public class Chef : Goblin
	{

		public Chef(Model model, Emploi emploi, double salaire, Goblin collegue, Goblin superieur, Difficulte difficulte) : base(model, emploi, salaire, collegue, superieur, difficulte)
	    {
	       
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
}