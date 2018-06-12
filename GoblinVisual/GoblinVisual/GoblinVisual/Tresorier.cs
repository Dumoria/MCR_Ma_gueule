public class Tresorier : Goblin
{

    Model model;

    public Tresorier(Emploi emploi, int salaire, Goblin collegue, Goblin superieur, Goblin employe)
{
    super(emploi, salaire, collegue, superieur, employe);
}


    public void valider(Requete requete)
    {
        occupe = false;
        model.addCoffre(requete.getSomme());
        passerSuperieur(requete);
    }
}
