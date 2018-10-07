using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour {

    public TypeCombattant combattant;

    public Ennemi(int classe, int niveau)
    {
        // Niveau set en fonction de la mission
        // 1 pour Guerrier
        if (classe == 0)
            Combattant = new Guerrier(niveau);
        // 2 pour Assassin
        if (classe == 1)
            Combattant = new Assassin(niveau);
        // 3 pour Sniper
        if (classe == 2)
            Combattant = new Sniper(niveau);
        // 4 pour Eclaireur
        if (classe == 3)
            Combattant = new Eclaireur(niveau);
    }

    public TypeCombattant Combattant
    {
        get
        {
            return combattant;
        }

        set
        {
            combattant = value;
        }
    }

    public void AttaqueAdversaire(TypeCombattant adversaire){
        adversaire.recoitDegats(Combattant);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
