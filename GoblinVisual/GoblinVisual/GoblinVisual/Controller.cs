
public class Controller
{

    Model model;
    Goblin currentGolbin;

    public boolean buyBonus(Bonus bonus)
    {
        if (bonus.getCost() > model.getArgentCoffre())
            return false;
        model.ajouterArgentCoffre(bonus.getCost());
        //prob traitement
    }

    public void engager()
    {
        model.ajouterMaillon(currentGolbin);
    }

    public void virer()
    {
        model.supprimerMaillon(currentGolbin);
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
