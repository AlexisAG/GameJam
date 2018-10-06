using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour {

    private bool estEnnemi; // J'en fait quoi 
    private int nbPaSoldat;
    private TypeCombattant combattant;

    public Ennemi(TypeCombattant.nomTypeCombattant typeComb, int niveau)
    {
        // Niveau set en fonction de la mission
        nbPaSoldat = 0;
        // 1 pour Guerrier
        if (typeComb == TypeCombattant.nomTypeCombattant.Guerrier)
            combattant = new Guerrier(niveau);
        // 2 pour Assassin
        if (typeComb == TypeCombattant.nomTypeCombattant.Assassin)
            combattant = new Assassin(niveau);
        // 3 pour Sniper
        if (typeComb == TypeCombattant.nomTypeCombattant.Sniper)
            combattant = new Sniper(niveau);
        // 4 pour Eclaireur
        if (typeComb == TypeCombattant.nomTypeCombattant.Eclaireur)
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
