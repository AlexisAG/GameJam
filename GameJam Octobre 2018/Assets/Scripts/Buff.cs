using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {
    //dzdq
    private Etat etatBuff;
    private int hpBuffDebuff;
    private int degatsBuffDebuff;
    public Buff(){
        EtatBuff = new Etat();
        NourritureOk();
    }
    public int HpBuffDebuff
    {
        get
        {
            return hpBuffDebuff;
        }

        set
        {
            hpBuffDebuff = value;
        }
    }

    public int DegatsBuffDebuff
    {
        get
        {
            return degatsBuffDebuff;
        }

        set
        {
            degatsBuffDebuff = value;
        }
    }

    public Etat EtatBuff
    {
        get
        {
            return etatBuff;
        }

        set
        {
            etatBuff = value;
        }
    }

    public void PasAssezDeNourriture()
    {
        this.HpBuffDebuff = - 1;
        this.DegatsBuffDebuff = - 2;
        this.EtatBuff.PasAssezDeNourriture();
    }

    public void TropDeNourriture()
    {
        this.HpBuffDebuff = 1;
        this.DegatsBuffDebuff = 2;
        this.EtatBuff.TropDeNourriture();
    }

    public void NourritureOk()
    {
        this.HpBuffDebuff = 0;
        this.DegatsBuffDebuff = 0;
        this.EtatBuff.NourritureOk();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
