using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour {

    private TypeCombattant combattant;

    public Ennemi(int classe, int niveau)
    {
        // Niveau set en fonction de la mission
        // 1 pour Guerrier
        if (classe == 0)
            combattant = new Guerrier(niveau);
        // 2 pour Assassin
        if (classe == 1)
            combattant = new Assassin(niveau);
        // 3 pour Sniper
        if (classe == 2)
            combattant = new Sniper(niveau);
        // 4 pour Eclaireur
        if (classe == 3)
            combattant = new Eclaireur(niveau);
    }

    public void AttaqueAdversaire(TypeCombattant adversaire){
        adversaire.recoitDegats(combattant);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
