using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain
{
    public int TypeCase { get; set; }
    public int Season { get; set; }  // 0 : Ete, 1 : Hiver // A CHANGER EN ENUM

    public float XPos { get; set; }
    public float YPos { get; set; }

    public bool IsFree { get; set; }
    public bool UnEnnemyDessus { get; set; }
    public bool UnSoldatDessus { get; set; }
    public bool EstUnObjectif { get; set; }

    public GameObject EnnemyDessus;
    public GameObject SoldatDessus;
    //public GameObject caseMesh;

    public Objectif Objectif;

    /* CHEMIN AUX MODELES */

    private string[][] terrainsPath =
    {
        new string[] // Été
        {
            "Modeles/Mesh_SolEteBase", // 0 Été
            "Modeles/Mesh_SolEtePierre", // 1 Été
            "Modeles/Mesh_SoEtelHerbe" // 2 Été
        },
        new string[] // Hiver
        {
            "Modeles/Mesh_SolHiverBase", // 3 Hiver
            "Modeles/Mesh_SolHiverPierre" // 4 Hiver
        }
    };

    private string[][] obstaclePath =
    {
        new string[] // Été
        {
            "Modeles/Mesh_ArbreEte", // 0 Été
            "Modeles/Mesh_Pierre"
        },
        new string[] // Hiver
        {
            "Modeles/Mesh_ArbreHiver", // 3 Hiver
            "Modeles/Mesh_Pierre" // 4 Hiver
        }
    };

    /* CONSTRUCTEUR */

    public Terrain (int m_typeCase, float m_xPos, float m_yPos, int m_season)
    {
        TypeCase = m_typeCase;
        XPos = m_xPos;
        YPos = m_yPos;
        Season = m_season;
        EstUnObjectif = false;

        if (m_typeCase == 1)
        {
            IsFree = true;
            int random = Mathf.FloorToInt(Random.Range(0, terrainsPath[Season].Length));
            Object.Instantiate<GameObject>(Resources.Load<GameObject>(terrainsPath[Season][random]), new Vector3(XPos, 0, YPos), Quaternion.identity);
        }
        else
        {
            IsFree = false;
            if (m_typeCase == 2)
            {
                int random = Mathf.FloorToInt(Random.Range(0, terrainsPath[Season].Length));
                int randomObstacle = Mathf.FloorToInt(Random.Range(0, obstaclePath[Season].Length));
                Object.Instantiate<GameObject>(Resources.Load<GameObject>(terrainsPath[Season][random]), new Vector3(XPos, 0, YPos), Quaternion.identity);
                Object.Instantiate<GameObject>(Resources.Load<GameObject>(obstaclePath[Season][randomObstacle]), new Vector3(XPos, 1, YPos), Quaternion.identity);
            }

        }

    }

}
