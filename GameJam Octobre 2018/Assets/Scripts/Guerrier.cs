using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : TypeCombattant {

    const string nameCombattant = "Guerrier";
    const int hpMin = 9;
    const int hpMax = 12;
    const int gainHpParNiveau = 3;

    const int degatsMin = 3;
    const int degatsMax = 6;
    const int gainDegatsParNiveau = 6;

    const int pa = 2;
    const int mpa = 4;
    const int range = 1;

    public Guerrier(int niveau = 1) : base(nameCombattant, hpMin, hpMax, gainHpParNiveau, degatsMin, degatsMax, gainDegatsParNiveau, pa, mpa, range, niveau)
    {
        LesCompetences.Add(new Competence("attaque forte",2,15,0,true));
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
