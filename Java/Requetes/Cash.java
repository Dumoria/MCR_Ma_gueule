/** @author Max
*/



public abstract class Cash extends Requete {

	
	protected int somme;

	public Cash(int somme) {
		somme = somme;
	}
		

	public int getSomme() {
		return somme;
	}

	@Override
	public boolean doitTraiter(Receptionniste r) {
		return true;
	}

	@Override
	public boolean doitTraiter(Tresorier t) {
		return true;
	}

	@Override
	public boolean doitTraiter(Tamponeur t) {
		return true;
	}
	
}