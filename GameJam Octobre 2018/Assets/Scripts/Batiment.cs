using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Batiment : MonoBehaviour {

    private string nom;
    private int niveauBatiment;
    private bool upgradePossible;
    private string sprite;
    private int coutEnRessources;
    private string typeRessourcePourUpgrade;

    public string Nom
    {
        get
        {
            return nom;
        }

        set
        {
            nom = value;
        }
    }

    public int NiveauBatiment
    {
        get
        {
            return niveauBatiment;
        }

        set
        {
            niveauBatiment = value;
        }
    }

    public string Sprite
    {
        get
        {
            return sprite;
        }

        set
        {
            sprite = value;
        }
    }

    public bool UpgradePossible
    {
        get
        {
            return upgradePossible;
        }

        set
        {
            upgradePossible = value;
        }
    }

    public string TypeRessourcePourUpgrade
    {
        get
        {
            return typeRessourcePourUpgrade;
        }

        set
        {
            typeRessourcePourUpgrade = value;
        }
    }

    public int CoutEnRessources
    {
        get
        {
            return coutEnRessources;
        }

        set
        {
            coutEnRessources = value;
        }
    }

    public abstract void Ameliorer();

    public void InitBatiment(Type typeBatiment)
    {
        Nom = typeBatiment + " Niv. 1";
        NiveauBatiment = 1;
        UpgradePossible = Inventaire.Instance.qteBois >= CoutEnRessources && TypeRessourcePourUpgrade == "bois" ? true : false;
        Sprite = "";
        CoutEnRessources = 10;
        TypeRessourcePourUpgrade = "bois";
        CoutEnRessources = 10;
    }
}
