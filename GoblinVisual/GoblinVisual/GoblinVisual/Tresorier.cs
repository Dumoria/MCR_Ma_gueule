public class Tresorier : Goblin
{

    Model model;

    public Tresorier(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe)
{
    super(emploi, salaire, collegue, superieur, employe);
}


    public void requeteTerminee(Requete requete){
        if (requete.getType().Name == "Pret")
        {
            model.addPrets(requete.getSomme());
        }
        else
        {
            model.addCoffre(requete.getSomme());
        }
        super.requeteTerminee(requete);
    }
}
