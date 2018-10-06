using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    private Etat etatBuff;
    private int hpBuffDebuff;
    private int degatsBuffDebuff;
    public Buff(){
        NourritureOk();
        EtatBuff = new Etat();
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
    }

    public void TropDeNourriture()
    {
        this.HpBuffDebuff = 1;
        this.DegatsBuffDebuff = 2;
    }

    public void NourritureOk()
    {
        this.HpBuffDebuff = 0;
        this.DegatsBuffDebuff = 0;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
