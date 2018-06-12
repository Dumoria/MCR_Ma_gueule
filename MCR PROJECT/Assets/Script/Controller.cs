namespace MODEL{
	public class Controller
	{

	    Model model;
	    Goblin currentGolbin;


	    public bool buyBonus(Bonus bonus)
	    {
	        if (bonus.getCost() > model.getArgentCoffre())
	            return false;
	        model.ajouterCoffre(bonus.getCost());
	        //prob traitement
	    }

	    public void selectionner(Goblin goblin)
	    {
	        currentGolbin = goblin;
	    }

	    public void generateRequests()
	    {

	    }

	    public void generateAlEvent()
	    {

	    }

	}
}
