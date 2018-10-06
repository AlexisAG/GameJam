﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : TypeCombattant {

	const int hpMin = 4;
	const int hpMax = 6;
	const int gainHpParNiveau = 1;

	const int degatsMin = 4;
	const int degatsMax = 8;
	const int gainDegatsParNiveau = 2;

	const int pa = 2;
	const int mpa = 7;
	const int range = 5;

	public Sniper(int niveau = 1){
		this.NomCombattant = "Sniper";
		this.HpCombattant = Random.Range(hpMin,hpMax) + niveau* gainHpParNiveau;
		this.DegatsCombattant = Random.Range(degatsMin,degatsMax) + niveau*gainDegatsParNiveau;
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
