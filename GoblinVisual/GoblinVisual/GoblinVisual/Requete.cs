/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Simon
 */
public class Requete
{

    /**
     * nombre de gobelin par etage de la hierarchie
     * demande pour traiter la requete
     */
    private int[] nbGobelinParClasse;

    /**
     * temps de traitement de la requete pour 
     * chaque type de gobelin dans la hierarchie
     */
    private int []tempsTraitement;

    public Requete(int[] nbGobelinParClasse, int[] tempsTraitement)
    {
        this.nbGobelinParClasse = nbGobelinParClasse;
        this.tempsTraitement = tempsTraitement;
    }

    /* Retourne un entier indiquant la position dans la
     * hierarchie du prochain type de goblin devant traiter
     * la requete ou -1 si elle est terminee
     */
    public int traiter(Emploi emploi)
    {
        int begin = (int) emploi;
        --nbGobelinParClasse[begin];
        for (int i = begin; i < nbGobelinParClasse.Length; ++i)
        {
            if (nbGobelinParClasse[i] != 0)
                return i;
        }
        return -1;
    }



    public int[] getNbGobelinParClasse()
    {
        return nbGobelinParClasse;
    }

    public int[] getTempsTraitement()
    {
        return tempsTraitement;
    }

    public int tempsTraitementPour(Emploi emploi)
    {
        return tempsTraitement[(int)emploi];
    }

}
