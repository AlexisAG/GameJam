using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : ScriptableObject
{
    private string classeString = "";
    public TypeCombattant combattant;
    public Buff buffCombattant;
    public GestionXP.NiveauXP niveauSoldat;
    public GestionXP.NiveauXP niveauSuivant;

    public Soldat(int classe)
    {
        buffCombattant = new Buff();
        this.niveauSoldat = new GestionXP.NiveauXP();

        if (classe == 0)
        {
            combattant = new Guerrier();
            classeString = "Guerrier";

        }
        // 1 pour Assassin
        if (classe == 1)
        {
            combattant = new Assassin();
            classeString = "Assassin";
        }
        // 2 pour Sniper
        if (classe == 2)
        {
            combattant = new Sniper();
            classeString = "Sniper";

        }
        // 3 pour Eclaireur
        if (classe == 3)
        {
            combattant = new Eclaireur();
            classeString = "Eclaireur";
        }

        if (this.niveauSoldat.XPActuelle >= this.niveauSoldat.XPMax)
            UpNiveau();
    }

    public string GetClasse()
    {
        return classeString;
    }

    public void AttaqueAdversaire(TypeCombattant adversaire)
    {
        adversaire.RecoitDegats(GetTypeCombattant(), GetBuffCombattant().DegatsBuffDebuff);
    }

    public void CheckEtat()
    {

    }

    public void UpNiveau(){
        double surplusXP = (GestionXP.Instance.gainXPMission + this.niveauSoldat.XPActuelle) - this.niveauSoldat.XPMax;
        GestionXP.Instance.AugmenterNiveauSoldat(this, surplusXP);
    }

    public TypeCombattant GetTypeCombattant()
    {
        return combattant;
    }

    public Buff GetBuffCombattant()
    {
        return buffCombattant;
    }

    public override string ToString()
    {
        return "\nType : " + GetTypeCombattant().NomCombattant +
               "\nHP : " + GetTypeCombattant().HpCombattant + "(+" + GetTypeCombattant().GainHpParNiveau +
               ")\n Degats : " + GetTypeCombattant().DegatsCombattant + "(+" + GetTypeCombattant().GainDegatsParNiveau +
               "\n PA : " + GetTypeCombattant().PaCombattant +
               "\nMPA : " + GetTypeCombattant().MpaCombattant +
               "\nRange : " + GetTypeCombattant().AttackRangeCombattant +
               "\nNiveau : " + GetTypeCombattant().NiveauCombattant;
    }
}
