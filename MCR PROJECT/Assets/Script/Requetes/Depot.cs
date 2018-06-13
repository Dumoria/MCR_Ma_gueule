/** @author Max
*/



namespace MODEL{
	public class Depot : Cash {

		public Depot (int somme) : base(somme) {}

		public override bool doitTraiter(Coffrier c) {
			return true;
		}

	}
}
