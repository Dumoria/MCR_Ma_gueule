using UnityEngine;
using System.Collections;

namespace MODEL{
		
	public class Test{

		static void Main(string[] args)
		{
			Model model = new Model ();
			while(!model.getLoose()){
				System.Console.WriteLine(model.getArgentCoffre());
			}
		}
	}

}