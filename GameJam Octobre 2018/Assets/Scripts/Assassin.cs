using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : TypeCombattant {

	const int hpMin = 3;
	const int hpMax = 5;
	const int gainHpParNiveau = 1;

	const int degatsMin = 5;
	const int degatsMax = 9;
	const int gainDegatsParNiveau = 2;

	const int pa = 3;
	const int mpa = 4;
	const int range = 1;

	public Assassin(){
		this.NomCombattant = "Assassin";
		this.HpCombattant = Random.Range(hpMin,hpMax);
        this.HpCombattantBuffDebuff = this.HpCombattant;
        this.DegatsCombattant = Random.Range(degatsMin,degatsMax);
        this.DegatsCombattantBuffDebuff = this.DegatsCombattant;
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
        this.ExperienceActuelCombattant = 0;
        this.ExperienceNiveauCombattant = 0;
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
