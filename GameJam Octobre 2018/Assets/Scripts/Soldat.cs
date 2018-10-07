using System.Collections;
using System.Collections.Generic;
using UnityEngine;

{

    private Buff buffCombattant;
    private string classe;
    private string GetClasse()
    {
        return classe;
    }

    public Soldat(TypeCombattant.nomTypeCombattant typeComb)
    {
        buffCombattant = new Buff();

        if (typeComb == TypeCombattant.nomTypeCombattant.Guerrier)
        {
            combattant = new Guerrier();
            classe = "Guerrier";
<<<<<<< HEAD
        }   
=======

>>>>>>> origin/AlexisAG
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
<<<<<<< HEAD
=======

>>>>>>> origin/AlexisAG
        }
        // 4 pour Eclaireur
        if (typeComb == TypeCombattant.nomTypeCombattant.Eclaireur)
        {
            combattant = new Eclaireur();
            classe = "Eclaireur";
        }
<<<<<<< HEAD
=======
>>>>>>> origin/AlexisAG
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
