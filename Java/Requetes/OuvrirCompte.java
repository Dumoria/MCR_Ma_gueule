/** @author Max
*/


namespace MODEL{
	class OuvrirCompte : Requete {

		
		public override bool doitTraiter(Receptionniste r) {
			return true;
		}
		
		public override bool doitTraiter(Coffrier c) {
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