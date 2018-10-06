using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MonoBehaviour
{

    private TypeCombattant combattant;
    private Buff buffCombattant;
    private int experienceActuel;
    private int experienceTotal;

    public Soldat(int classe)
    {
        buffCombattant = new Buff();
        this.experienceTotal = 5000;
        experienceActuel = 0;
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
    }

    public void AttaqueAdversaire(TypeCombattant adversaire)
    {
        adversaire.RecoitDegats(GetTypeCombattant(), buffCombattant.DegatsBuffDebuff);
    }

    public void CheckEtat()
    {

    }

    public void UpNiveau(){
        experienceTotal += 1000;
        experienceActuel = 0;
        GetTypeCombattant().UpNiveauCombattant();
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
