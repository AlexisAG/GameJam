using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldat : MonoBehaviour
{

    private TypeCombattant combattant;
    private Buff buffCombattant;

    public Soldat(int classe)
    {
        buffCombattant = new Buff();
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
