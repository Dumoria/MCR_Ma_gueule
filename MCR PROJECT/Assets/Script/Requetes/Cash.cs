/** @author Max
*/



namespace MODEL{
	public abstract class Cash : Requete {

	
		protected int somme;

		public Cash(int somme) {
			somme = somme;
		}
			

		public int getSomme() {
			return somme;
		}


		public override bool doitTraiter(Receptionniste r) {
			return true;
		}
		
		public override bool doitTraiter(Tresorier t) {
			return true;
		}

		public override bool doitTraiter(Tamponeur t) {
			return true;
		}
	}
}