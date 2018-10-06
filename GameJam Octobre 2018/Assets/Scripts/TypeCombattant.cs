using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypeCombattant : MonoBehaviour {

    public enum nomTypeCombattant { Guerrier, Assassin, Sniper, Eclaireur }
    private string nomCombattant;
    private int hpCombattant;
    private int degatsCombattant;
    private int paCombattant;
    private int mpaCombattant;
    private int attackRangeCombattant;
    private List<Competence> lesCompetences;
    private int niveauCombattant;

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

    public int ExperienceActuelCombattant
    {
        get
        {
            return experienceActuelCombattant;
        }

        set
        {
            experienceActuelCombattant = value;
        }
    }

    public int ExperienceNiveauCombattant
    {
        get
        {
            return experienceNiveauCombattant;
        }

        set
        {
            experienceNiveauCombattant = value;
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

    public abstract void UpNiveauCombattant();

}
