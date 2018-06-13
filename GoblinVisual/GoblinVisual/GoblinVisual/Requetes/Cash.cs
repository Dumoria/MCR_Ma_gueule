/** @author Max
*/

using Requete


abstract class Cash : Requete {

	public Cash (int somme) {
		somme = somme;
	}

	protected int somme;

	public getSomme() {
		return somme;
	}


	public override bool doitTraiter(Receptionniste r) {
		return true;
	}
	
	public override bool doitTraiter(Tresorier t) {
		return true;
	}

	public override bool doitTraiter(Tamponneur t) {
		return true;
	}
}
