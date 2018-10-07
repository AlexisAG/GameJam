using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : TypeCombattant {

    const string nameCombattant = "Sniper";
	const int hpMin = 4;
	const int hpMax = 6;
	const int gainHpParNiveau = 1;

	const int degatsMin = 4;
	const int degatsMax = 8;
	const int gainDegatsParNiveau = 2;

	const int pa = 2;
	const int mpa = 7;
	const int range = 5;

    public Sniper(int niveau = 1) : base(nameCombattant, hpMin, hpMax, gainHpParNiveau, degatsMin, degatsMax, gainDegatsParNiveau, pa, mpa, range, niveau)
    {
        LesCompetences.Add(new Competence("attaque précise", 2, 17, 0, true));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
