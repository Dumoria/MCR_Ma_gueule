/** @author Max
*/




public class PayementSalaire extends Requete {

	@Override
	public bool doitTraiter(Tresorier t) {
		return true;
	}

	@Override
	public bool doitTraiter(Tamponeur t) {
		return true;
	}

	@Override
	public bool doitTraiter(Chef c) {
		return true;
	}
}
