using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Batiment : MonoBehaviour {

    private string nom;
    private int niveauBatiment;
    private bool upgradePossible;
    private string sprite;
    private int cout;

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

    public int Cout
    {
        get
        {
            return cout;
        }

        set
        {
            cout = value;
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

    public abstract void Ameliorer();
}
