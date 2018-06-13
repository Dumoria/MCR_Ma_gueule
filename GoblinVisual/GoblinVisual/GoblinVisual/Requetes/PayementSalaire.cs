/** @author Max
*/

using Requete


class PayementSalaire : Requete {

	
	public override bool doitTraiter(Tresorier t) {
		return true;
	}

	public override bool doitTraiter(Tamponneur t) {
		return true;
	}
	
	public override bool doitTraiter(Chef c) {
		return true;
	}
}
