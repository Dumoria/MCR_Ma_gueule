import


public enum Emploi
{
	Receptionniste = 0,
	Coffrier = 1,
	Tresorier = 2,
	Tamponeur = 3,
	Chef = 4
}

public class Salaire
{
	private static double[] salaires;

	public Salaire(){
		salaires.Add (100);
		salaires.Add (150);
		salaires.Add (225);
		salaires.Add (300);
		salaires.Add (500);
	}

	public static double getSalaire(int index){
		return salaires[index];
	}

	public static double getSalaire(Emploi emploi){
		return salaires[(int) emploi];
	}
}
