/** @author Max
*/



namespace MODEL{
	class TraiterBeuglantes : Requete {

		
		public override bool doitTraiter(Receptionniste r) {
			return true;
		}

		
		public override bool doitTraiter(Chef c) {
			return true;
		}
	}
}