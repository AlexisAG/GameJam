using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guerrier : TypeCombattant {

    const int hpMin = 9;
    const int hpMax = 12;
    const int gainHpParNiveau = 3;

    const int degatsMin = 3;
    const int degatsMax = 6;
    const int gainDegatsParNiveau = 6;

    const int pa = 2;
    const int mpa = 4;
    const int range = 1;

    public Guerrier(int niveau = 1)
    {
        this.NomCombattant = "Guerrier";
        this.HpCombattant = Random.Range(hpMin, hpMax) + niveau * gainHpParNiveau;
        this.DegatsCombattant = Random.Range(degatsMin, degatsMax) + niveau * gainDegatsParNiveau;
        this.PaCombattant = pa;
        this.MpaCombattant = mpa;
        this.AttackRangeCombattant = range;
        this.ExperienceActuelCombattant = 0;
        this.ExperienceNiveauCombattant = 0;
        this.NiveauCombattant = 1;
    }

    public override void UpNiveauCombattant()
    {
        this.NiveauCombattant++;
        this.HpCombattant += gainHpParNiveau;
        this.DegatsCombattant += gainDegatsParNiveau;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
