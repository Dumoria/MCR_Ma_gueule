
namespace MODEL{

	public abstract class BonusModel
	{

	    private int cost;
		public static int niveau=0;

        
		public BonusModel(int cost){
			this.cost = cost;
		}

		public void incrementeNiveau(){
			if (niveau < 5) {
				++niveau;
				cost *= 2;
			}
		}
        
		public void setCost(int cost){
			this.cost=cost;
		}

	    public int getCost()
	    {
	        return cost;
	    }

		public int getNiveau(){
			return niveau;
		}
	}
}