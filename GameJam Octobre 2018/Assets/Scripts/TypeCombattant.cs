using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCombattant : MonoBehaviour {

    public enum nomTypeCombattant { Guerrier, Assassin, Sniper, Eclaireur }
    private string nomCombattant;
    private int hpCombattant;
    private int degatsCombattant;
    private int paCombattant;
    private int mpaCombattant;
    private int attackRangeCombattant;
    private int gainHpParNiveau;
    private int gainDegatsParNiveau;
    private List<Competence> lesCompetences;
    private int niveauCombattant;
    public TypeCombattant(string nameCombattant,int hpMin, int hpMax, int t_gainHpParNiveau, int degatsMin, int degatsMax, int t_gainDegatsParNiveau, int pa, int mpa, int range, int niveau)
    {
        this.NomCombattant = nameCombattant;
        this.HpCombattant = Random.Range(hpMin, hpMax) + niveau * t_gainHpParNiveau;
        this.DegatsCombattant = Random.Range(degatsMin, degatsMax) + niveau * t_gainDegatsParNiveau;
        this.GainHpParNiveau = t_gainHpParNiveau;
        this.GainDegatsParNiveau = t_gainDegatsParNiveau;
        this.PaCombattant = pa;
        this.MpaCombattant = mpa;
        this.AttackRangeCombattant = range;
        this.NiveauCombattant = 1;
    }
    public void recoitDegats(TypeCombattant adversaire, int degatsBuff = 0){
        this.HpCombattant -= adversaire.DegatsCombattant + degatsBuff;
        if(HpCombattant <=0){
            // Faut le faire mourrir
        }
    }
    public string NomCombattant
    {
        get
        {
            return nomCombattant;
        }

        set
        {
            nomCombattant = value;
        }
    }

    public int HpCombattant
    {
        get
        {
            return hpCombattant;
        }

        set
        {
            hpCombattant = value;
        }
    }

    public int DegatsCombattant
    {
        get
        {
            return degatsCombattant;
        }

        set
        {
            degatsCombattant = value;
        }
    }

    public int PaCombattant
    {
        get
        {
            return paCombattant;
        }

        set
        {
            paCombattant = value;
        }
    }

    public int MpaCombattant
    {
        get
        {
            return mpaCombattant;
        }

        set
        {
            mpaCombattant = value;
        }
    }

    public int AttackRangeCombattant
    {
        get
        {
            return attackRangeCombattant;
        }

        set
        {
            attackRangeCombattant = value;
        }
    }

    public List<Competence> LesCompetences
    {
        get
        {
            return lesCompetences;
        }

        set
        {
            lesCompetences = value;
        }
    }

    public int NiveauCombattant
    {
        get
        {
            return niveauCombattant;
        }

        set
        {
            niveauCombattant = value;
        }
    }

    public int GainHpParNiveau
    {
        get
        {
            return gainHpParNiveau;
        }

        set
        {
            gainHpParNiveau = value;
        }
    }

    public int GainDegatsParNiveau
    {
        get
        {
            return gainDegatsParNiveau;
        }

        set
        {
            gainDegatsParNiveau = value;
        }
    }

    public void UpNiveauCombattant(){
        this.NiveauCombattant++;
        this.HpCombattant += GainHpParNiveau;
        this.DegatsCombattant += GainDegatsParNiveau;
    }

}
