using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : ScriptableObject
{

<<<<<<< HEAD
    private string classe = "";
    public TypeCombattant combattant;
    private Buff buffCombattant;
=======
    private TypeCombattant combattant;
    public Buff buffCombattant;
    public GestionXP.NiveauXP niveauSoldat;
    public GestionXP.NiveauXP niveauSuivant;
>>>>>>> origin/Flotest

    public Soldat(int classe)
    {
        buffCombattant = new Buff();
<<<<<<< HEAD

        if (typeComb == TypeCombattant.nomTypeCombattant.Guerrier)
        {
            combattant = new Guerrier();
            classe = "Guerrier";

        }
        // 2 pour Assassin
        if (typeComb == TypeCombattant.nomTypeCombattant.Assassin)
        {
            combattant = new Assassin();
            classe = "Assassin";
        }
        // 3 pour Sniper
        if (typeComb == TypeCombattant.nomTypeCombattant.Sniper)
        {
            combattant = new Sniper();
            classe = "Sniper";

        }
        // 4 pour Eclaireur
        if (typeComb == TypeCombattant.nomTypeCombattant.Eclaireur)
        {
            combattant = new Eclaireur();
            classe = "Eclaireur";
        }
    }

    public string GetClasse()
    {
        return classe;
=======
        this.niveauSoldat = new GestionXP.NiveauXP();
        // 0 pour Guerrier
        if (classe == 0)
            combattant = new Guerrier();
        // 1 pour Assassin
        if (classe == 1)
            combattant = new Assassin();
        // 2 pour Sniper
        if (classe == 2)
            combattant = new Sniper();
        // 3 pour Eclaireur
        if (classe == 3)
            combattant = new Eclaireur();

        if (this.niveauSoldat.XPActuelle >= this.niveauSoldat.XPMax)
            UpNiveau();
>>>>>>> origin/Flotest
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
