﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Objectif {

    private float xPos;
    private float yPos;
    private int typeObjectif;

    private string[] objectifPath =
    {
        "Assets/Modeles/Mesh_coffre.fbx", // 0 : Ressource
        "Assets/Modeles/Mesh_civil.fbx" // 1 : Civil
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

        Object.Instantiate<GameObject>(AssetDatabase.LoadAssetAtPath<GameObject>(objectifPath[m_typeObjectif]), new Vector3(XPos, 0.5f, YPos), Quaternion.identity);
    }
}
