/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

public class Model
{

    /**
     * nombre de classe hierarchique dans la banque
     */
    private int argentCoffre = 3000;
    private int nbRequetes = 0;

    private List<List<Goblin>> employes = new List<List<Goblin>>();
    private List<Requete> requetes = new List<Requete>();
    private Random random = new Random();

    private Difficulte difficulte;
    private Timer requetesFlot;

    public Model()
    {
        employes.add(new List<Receptionniste>());
        employes.add(new List<Coffrier>());
        employes.add(new List<Tresorier>());
        employes.add(new List<Tamponeur>());
        employes.add(new List<Chef>());

        difficulte = new Difficulte(5, 40, 5); //Predecl pour diff facile

        requetesFlot = new Timer(difficulte.getDebitRequetes());
        requetesFlot.Elapsed += generateRequest(); 
        requetesFlot.start();
    }

    public void ajouterCoffre(int nbGold)
    {
        argentCoffre += nbGold;
    }

    public Goblin getEmploye(int indexEmploi, int indexEmploye)
    {
        return employes[indexEmploi][indexEmploye];
    }

    public void seFaireBraquer()
    {
        argentCoffre /= 2;
        addStress(20);
    }

    public void addStress(int prc)
    {
        for(int i = 0; i < employes.Length; ++i)
        {
            List<Goblin> classe = employes[i];
            for (int j = 0; j < employes[i].Length; ++j)
            {
                int stress = classe[j].getStress() + prc;
                if(stress < 0)
                {
                    classe[j].setStress(0);
                }else if(stress > 100)
                {
                    classe[j].setStress(100);
                }
                else
                {
                    classe[j].setStress(classe[j].getStress() - prc);
                }
            }
        }
    }

    public void generateSomeRequests()
    {

        requetes.add(generateARequest());  
        employes.get(0).get(0).handleRequest(requetes.get(0));
        requetes.RemoveAt(0);

        requetesFlot = new Timer(2000);
        requetesFlot.Elapsed += generateSomeRequests();
        requetesFlot.start();
    }

    public Request generateARequest()
    {
        int typeRequete = random.Next() % 9;
        Requete requete;
        ++nbRequetes;

        switch (typeRequete)
        {
            case 0:
                requete = new CertificatFortune();
                break;
            case 1:
                requete = new Retrait();
                break;
            case 2:
                requete = new Depot();
                break;
            case 3:
                requete = new Remboursement();
                break;
            case 4:
                requete = new Emprunt();
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

    public void ajouterMaillon(Goblin goblin)
    {
        List<Goblin> tmp = employes.get((int)goblin.getEmploi());
        tmp[tmp.Count - 1].setCollegue(goblin);
        goblin.setSuperieur(tmp[0].getSuperieur());
        tmp.add(goblin);
    }

    bool supprimerMaillon(Goblin goblin)
    {
        List<Goblin> collegues = employes.get((int)goblin.getEmploi());
        if (collegues.Length == 1)
        {
            Console.writeLine("Can't fire the last employe");
            return false;
        }
        else {
            employes.get((int)goblin.getEmploi()).remove(goblin);
            return true;
        }
    }

}
