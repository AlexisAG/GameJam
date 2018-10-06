using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : TypeCombattant {

    const string nameCombattant = "Assassin";
    const int hpMin = 3;
	const int hpMax = 5;
	const int gainHpParNiveau = 1;

	const int degatsMin = 5;
	const int degatsMax = 9;
	const int gainDegatsParNiveau = 2;

	const int pa = 3;
	const int mpa = 4;
	const int range = 1;

    public Assassin(int niveau = 1) : base(nameCombattant, hpMin, hpMax, gainHpParNiveau, degatsMin, degatsMax, gainDegatsParNiveau, pa, mpa, range, niveau)
    {

    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
