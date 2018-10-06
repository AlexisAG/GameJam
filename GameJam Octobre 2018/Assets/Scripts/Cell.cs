using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Cell {

    private Vector2 position;
    private float gCost;// distance start
    private float hCost;// distance end
    private float fCost;// hcost + gcost

    private Cell predecesseur;

    public Vector2 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
        }
    }

    public float GCost
    {
        get
        {
            return gCost;
        }

        set
        {
            gCost = value;
        }
    }

    public float HCost
    {
        get
        {
            return hCost;
        }

        set
        {
            hCost = value;
        }
    }

    public float FCost
    {
        get
        {
            return fCost;
        }

        set
        {
            fCost = value;
        }
    }

    public Cell Predecesseur
    {
        get
        {
            return predecesseur;
        }

        set
        {
            predecesseur = value;
        }
    }

    public Cell(Vector2 m_Position, float m_gcost, float m_hcost , Cell m_predecesseur)
    {
        Position = m_Position;
        GCost = m_gcost;
        HCost = m_hcost;
        FCost = GCost + HCost;
        Predecesseur = m_predecesseur;
        Object.Instantiate<GameObject>(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Modeles/Mesh_arbalete.fbx"), new Vector3(Position.x, 1, Position.y), Quaternion.identity);
    }

    public void UpdateFCost()
    {
        FCost = GCost + HCost;
    }
}
