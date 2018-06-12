/** @author Max
*/

using Requete


class OuvrirCompte : Requete {

	
	public override bool doitTraiter(Receptionniste r) {
		return true;
	}
	
	public override bool doitTraiter(Coffrier c) {
		return true;
	}

	public override bool doitTraiter(Tamponneur t) {
		return true;
	}
	
	public override bool doitTraiter(Chef c) {
		return true;
	}
}
