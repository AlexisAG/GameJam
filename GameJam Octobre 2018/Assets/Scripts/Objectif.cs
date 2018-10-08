using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Objectif {

    private float xPos;
    private float yPos;
    private int typeObjectif;

    public GameObject Mesh;

    private string[] objectifPath =
    {
        "", // 0
        "Modeles/Mesh_coffre", // 1 : Ressource
        "Modeles/Mesh_civil" // 2 : Civil
    };



    public float XPos
    {
        get
        {
            return xPos;
        }

        set
        {
            xPos = value;
        }
    }

    public float YPos
    {
        get
        {
            return yPos;
        }

        set
        {
            yPos = value;
        }
    }

    public int TypeObjectif
    {
        get
        {
            return typeObjectif;
        }

        set
        {
            typeObjectif = value;
        }
    }

    public Objectif(float m_xPos, float m_yPos, int m_typeObjectif)
    {
        XPos = m_xPos;
        YPos = m_yPos;
        TypeObjectif = m_typeObjectif;
        if(typeObjectif != 0)
        {
            Mesh = Object.Instantiate<GameObject>(Resources.Load<GameObject>(objectifPath[m_typeObjectif]), new Vector3(XPos, 0.5f, YPos), Quaternion.identity);
        }
        
    }
}
