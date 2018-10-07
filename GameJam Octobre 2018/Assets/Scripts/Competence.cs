using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Competence : MonoBehaviour {

	private string nomCompetence;
	private int coutCompetence;
	private int degatsCompetence;
	private int cooldownCompetence;
    private Sprite imageCompetence;
    private bool estDispoCompetence;

    public string NomCompetence
    {
        get
        {
            return nomCompetence;
        }

        set
        {
            nomCompetence = value;
        }
    }

    public int CoutCompetence
    {
        get
        {
            return coutCompetence;
        }

        set
        {
            coutCompetence = value;
        }
    }

    public int DegatsCompetence
    {
        get
        {
            return degatsCompetence;
        }

        set
        {
            degatsCompetence = value;
        }
    }

    public int CooldownCompetence
    {
        get
        {
            return cooldownCompetence;
        }

        set
        {
            cooldownCompetence = value;
        }
    }

    public Sprite ImageCompetence
    {
        get
        {
            return imageCompetence;
        }

        set
        {
            imageCompetence = value;
        }
    }

    public bool EstDispoCompetence
    {
        get
        {
            return estDispoCompetence;
        }

        set
        {
            estDispoCompetence = value;
        }
    }

    public Competence(string m_nomcompetence, int m_coutcompetence, int m_degatscompetences, int m_cooldowncompetence, bool m_estdispocompetence)
    {
        NomCompetence = m_nomcompetence;
        CoutCompetence = m_coutcompetence;
        DegatsCompetence = m_degatscompetences;
        CooldownCompetence = m_cooldowncompetence;
        EstDispoCompetence = m_estdispocompetence;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
