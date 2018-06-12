/** @author Max
*/



namespace MODEL{
	public class PayementSalaire : Requete {

		
		public override bool doitTraiter(Tresorier t) {
			return true;
		}

		public override bool doitTraiter(Tamponeur t) {
			return true;
		}
		
		public override bool doitTraiter(Chef c) {
			return true;
		}
	}
}