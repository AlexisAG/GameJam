using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : ScriptableObject
{

    public TypeCombattant combattant;
    private string classeString = "";

    public Ennemi(int classe, int niveau)
    {
        // Niveau set en fonction de la mission
        if (classe == 0)
        {
            combattant = new Guerrier();
            classeString = "Guerrier";

        }
        // 1 pour Assassin
        if (classe == 1)
        {
            combattant = new Assassin();
            classeString = "Assassin";
        }
        // 2 pour Sniper
        if (classe == 2)
        {
            combattant = new Sniper();
            classeString = "Sniper";

        }
        // 3 pour Eclaireur
        if (classe == 3)
        {
            combattant = new Eclaireur();
            classeString = "Eclaireur";
        }
    }

    public string GetClasse()
    {
        return classeString;
    }

    public void AttaqueAdversaire(TypeCombattant adversaire){
        adversaire.RecoitDegats(combattant);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
