using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypeCombattant : MonoBehaviour {

    private string nomCombattant;
    private int hpCombattant;
    private int hpCombattantBuffDebuff;
    private int paCombattant;
    private int mpaCombattant;
    private int degatsCombattant;
    private int degatsCombattantBuffDebuff;
    private int attackRangeCombattant;
    private List<Competence> lesCompetences;
    private int experienceActuelCombattant;
    private int experienceNiveauCombattant;
    private int niveauCombattant;
    
    public void PasAssezDeNourriture(){
        this.DegatsCombattantBuffDebuff = this.DegatsCombattant - 1;
        this.HpCombattantBuffDebuff = this.HpCombattant - 2;
    }

    public void TropDeNourriture()
    {
        this.DegatsCombattantBuffDebuff = this.DegatsCombattant + 1;
        this.HpCombattantBuffDebuff = this.HpCombattant + 2;
    }

    public void NourritureOk()
    {
        this.DegatsCombattantBuffDebuff = this.DegatsCombattant;
        this.HpCombattantBuffDebuff = this.HpCombattant;
    }
    public abstract void UpNiveauCombattant();
    protected string NomCombattant
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

    protected int HpCombattant
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

    protected int PaCombattant
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

    protected int MpaCombattant
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

    protected int DegatsCombattant
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

    protected int AttackRangeCombattant
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

    protected List<Competence> LesCompetences
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

    protected int ExperienceActuelCombattant
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

    protected int ExperienceNiveauCombattant
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

    public int DegatsCombattantBuffDebuff
    {
        get
        {
            return degatsCombattantBuffDebuff;
        }

        set
        {
            degatsCombattantBuffDebuff = value;
        }
    }

    public int HpCombattantBuffDebuff
    {
        get
        {
            return hpCombattantBuffDebuff;
        }

        set
        {
            hpCombattantBuffDebuff = value;
        }
    }
}
