using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MonoBehaviour
{

    private TypeCombattant combattant;
    public Buff buffCombattant;

    public Soldat(TypeCombattant.nomTypeCombattant typeComb)
    {
        buffCombattant = new Buff();

        if (typeComb == TypeCombattant.nomTypeCombattant.Guerrier)
            combattant = new Guerrier();
        // 2 pour Assassin
        if (typeComb == TypeCombattant.nomTypeCombattant.Assassin)
            combattant = new Assassin();
        // 3 pour Sniper
        if (typeComb == TypeCombattant.nomTypeCombattant.Sniper)
            combattant = new Sniper();
        // 4 pour Eclaireur
        if (typeComb == TypeCombattant.nomTypeCombattant.Eclaireur)
            combattant = new Eclaireur();
    }

    public void AttaqueAdversaire(TypeCombattant adversaire)
    {
        adversaire.recoitDegats(combattant, buffCombattant.DegatsBuffDebuff);
    }

    public void CheckEtat()
    {

        if (buffCombattant.EtatBuff.NomEtat == Etat.etatFaible)
        {
            buffCombattant.PasAssezDeNourriture();
        }
        if (buffCombattant.EtatBuff.NomEtat == Etat.etatNeutre)
        {
            buffCombattant.NourritureOk();
        }
        if (buffCombattant.EtatBuff.NomEtat == Etat.etatEnForme)
        {
            buffCombattant.TropDeNourriture();
        }
    }

    public TypeCombattant GetTypeCombattant()
    {
        return combattant;
    }
}
