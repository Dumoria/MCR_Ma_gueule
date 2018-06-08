/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package banquegobeline;

/**
 *
 * @author Simon
 */
public class Requete {
    
    /**
     * nombre de gobelin par etage de la hierarchie
     * demande pour traiter la requete
     */
    private int nbGobelinParClasse[];
    
    /**
     * temps de traitement de la requete pour 
     * chaque type de gobelin dans la hierarchie
     */
    private int tempsTraitement[];
    
    private String typeRequete;
    
    public Requete(int nbGobelinParClasse[], int tempsTraitement[]) {
        this.nbGobelinParClasse = nbGobelinParClasse;
        this.tempsTraitement = tempsTraitement;
    }
    
    public int[] getNbGobelinParClasse() {
        return nbGobelinParClasse;
    }
    
    public int[] getTempsTraitement() {
        return tempsTraitement;
    }
    
    /*
     * la requete est partiellement traitee, on 
     * peut retirer un gobelin de la meme classe 
     * hierarchique necessaire a traiter la requete
     */
    public void traiter(Gobelin gobelin) {
        if(nbGobelinParClasse[gobelin.getEmploi()] > 1) {
            nbGobelinParClasse[gobelin.getEmploi()]--;
        }
    }
    
    public boolean requeteCompletee() {
        for(int classe : nbGobelinParClasse) {
            if(nbGobelinParClasse[classe] != 0) {
                return false;
            }
        }
        return true;
    }
}
