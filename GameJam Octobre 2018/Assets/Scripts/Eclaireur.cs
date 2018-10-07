using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eclaireur : TypeCombattant {

    const string nameCombattant = "Eclaireur";
    const int hpMin = 5;
    const int hpMax = 9;
    const int gainHpParNiveau = 2;

    const int degatsMin = 1;
    const int degatsMax = 3;
    const int gainDegatsParNiveau = 1;

    const int pa = 2;
    const int mpa = 7;
    const int range = 1;

    public Eclaireur(int niveau = 1) : base(nameCombattant, hpMin, hpMax, gainHpParNiveau, degatsMin, degatsMax, gainDegatsParNiveau, pa, mpa, range, niveau)
    {
        LesCompetences.Add(new Competence("attaque calculée", 2, 12, 0, true));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
