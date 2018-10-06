using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Terrain {
    //temp
    private int typeCase;
    private float xPos;
    private float yPos;
    private bool isFree;
    private int season; // 0 : Ete, 1 : Hiver
    //public GameObject caseMesh;
    private string[][] terrainsPath =
    {
        new string[] // Été
        {
            "Assets/Modeles/Mesh_SolEteBase.fbx", // 0 Été
            "Assets/Modeles/Mesh_SolEtePierre.fbx", // 1 Été
            "Assets/Modeles/Mesh_SolHerbe.fbx" // 2 Été
        },
        new string[] // Hiver
        {
            "Assets/Modeles/Mesh_SolHiverBase.fbx", // 3 Hiver
            "Assets/Modeles/Mesh_SolHiverPierre.fbx" // 4 Hiver
        }
    };

    public int TypeCase
    {
        get
        {
            return typeCase;
        }

        set
        {
            typeCase = value;
        }
    }

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

    public bool IsFree
    {
        get
        {
            return isFree;
        }

        set
        {
            isFree = value;
        }
    }

    public int Season
    {
        get
        {
            return season;
        }

        set
        {
            season = value;
        }
    }

    public Terrain(int m_typeCase, float m_xPos, float m_yPos, int m_season)
    {
        TypeCase = m_typeCase;
        XPos = m_xPos;
        YPos = m_yPos;
        Season = m_season;
        if(m_typeCase == 1)
        {
            IsFree = true;
            int random = Mathf.FloorToInt(Random.Range(0, terrainsPath[Season].Length));
            Object.Instantiate<GameObject>(AssetDatabase.LoadAssetAtPath<GameObject>(terrainsPath[Season][random]), new Vector3(XPos, 0, YPos), Quaternion.identity);
        } else
        {
            IsFree = false;
            if(m_typeCase == 2)
            {
                int random = Mathf.FloorToInt(Random.Range(0, terrainsPath[Season].Length));
                Object.Instantiate<GameObject>(AssetDatabase.LoadAssetAtPath<GameObject>(terrainsPath[Season][random]), new Vector3(XPos, 0, YPos), Quaternion.identity);
                Object.Instantiate<GameObject>(AssetDatabase.LoadAssetAtPath<GameObject>(terrainsPath[Season][random]), new Vector3(XPos, 1, YPos), Quaternion.identity);
            }
        }
        
        
        
        
    }
}
