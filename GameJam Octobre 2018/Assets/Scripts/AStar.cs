using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AStar {
    private Cell depart;
    private Cell arrive;
    private Cell currentPos;
    private List<Cell> ouvert = new List<Cell>();
    private List<Cell> voisins = new List<Cell>();
    private bool Fini=false;
    private GenerateurDeCarte terrain;

    public Cell Depart
    {
        get
        {
            return depart;
        }

        set
        {
            depart = value;
        }
    }

    public Cell Arrive
    {
        get
        {
            return arrive;
        }

        set
        {
            arrive = value;
        }
    }

    public void ResetAStar(Vector2 m_depart, Vector2 m_arrive)
    {
        Depart = new Cell(m_depart, 0, 0, null);
        Arrive = new Cell(m_arrive, 0, 0, null);
        currentPos = Depart;
        ouvert = new List<Cell>();
        ouvert.Add(Depart);
        voisins = new List<Cell>();
        Fini = false;
        terrain = null;
    }

    public AStar(Vector2 m_Depart, Vector2 m_Arrive)
    {
        Depart = new Cell(m_Depart,0,0,null);
        Arrive = new Cell(m_Arrive, 0, 0, null);
        currentPos = Depart;
        ouvert.Add(Depart);
        terrain = GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>();
    }



    public List<Vector2> CalculerTrajet()
    {
        if(Depart.Position == Arrive.Position)
        {
            return new List<Vector2>();
        } else
        {
            terrain = GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>();
            while (Fini == false)
            {
                ChercherVoisins(currentPos);
                UpdateCurrentPos();
                CheckIfArrived();
            }

            List<Vector2> trajet = new List<Vector2>();

            while (currentPos.Predecesseur != null)
            {
                trajet.Add(currentPos.Position);
                currentPos = currentPos.Predecesseur;
            }

            return trajet;
        }
        
        
    }

    public void ChercherVoisins(Cell current)
    {
        Debug.Log("Je rentre dans chercher voisins");
        List<Vector2> voisinPos = new List<Vector2>();
        List<Vector2> voisinClean = new List<Vector2>();

        if (terrain.Tableauterrain[new Vector2Int((int)current.Position.x + 1, (int)current.Position.y)].IsFree)
        {
            Debug.Log("1 debut");
            voisinPos.Add(new Vector2(current.Position.x + 1, current.Position.y));
            voisinClean.Add(new Vector2(current.Position.x + 1, current.Position.y));
            Debug.Log("1 fin");
        }

        if (terrain.Tableauterrain[new Vector2Int((int)current.Position.x - 1, (int)current.Position.y)].IsFree)
        {
            Debug.Log("2 debut");
            voisinPos.Add(new Vector2(current.Position.x - 1, current.Position.y));
            voisinClean.Add(new Vector2(current.Position.x - 1, current.Position.y));
            Debug.Log("2 fin");
        }

        if (terrain.Tableauterrain[new Vector2Int((int)current.Position.x , (int)current.Position.y + 1)].IsFree)
        {
            Debug.Log("3 debut");
            voisinPos.Add(new Vector2(current.Position.x, current.Position.y + 1));
            voisinClean.Add(new Vector2(current.Position.x, current.Position.y + 1));
            Debug.Log("3 fin");
        }

        if (terrain.Tableauterrain[new Vector2Int((int)current.Position.x , (int)current.Position.y - 1)].IsFree)
        {
            Debug.Log("4 debut");
            voisinPos.Add(new Vector2(current.Position.x, current.Position.y - 1));
            voisinClean.Add(new Vector2(current.Position.x, current.Position.y - 1));
            Debug.Log("4 debut");
        }

        foreach (Cell voisin in voisins)
        {
            if (voisinPos.Count > 0)
            {
                foreach (Vector2 voisintest in voisinPos)
                {
                    if (voisintest == Depart.Position)
                    {
                        voisinClean.Remove(voisintest);
                    }
                    else if (voisintest == voisin.Position)
                    {
                        if (current.HCost + 10 < voisin.HCost)
                        {
                            voisin.HCost = current.HCost + 10;
                        }

                        voisin.UpdateFCost();
                        voisinClean.Remove(voisintest);
                    }
                }
            }

        }

        


        Debug.Log("Avant ajout de cell");
        foreach (Vector2 nouveauVoisin in voisinClean.ToArray())
        {
            voisins.Add(new Cell(nouveauVoisin,current.GCost+1,Mathf.Sqrt(Mathf.Pow(Arrive.Position.x-nouveauVoisin.x,2)+ Mathf.Pow(Arrive.Position.y - nouveauVoisin.y, 2)) * 1.75f,current));
        }

        Debug.Log("Je sors dans chercher voisins");
    }

    public void UpdateCurrentPos()
    {
        Cell nextStep = null;
        foreach (Cell voisin in voisins)
        {
            if(nextStep == null)
            {
                bool inOuvert = false;
                foreach (Cell ouvertCell in ouvert)
                {
                    if(voisin == ouvertCell)
                    {
                        inOuvert = true;
                    }
                }
                if(inOuvert == false)
                {
                    nextStep = voisin;
                }
            }
            else if(voisin.FCost == nextStep.FCost)
            {
                bool inOuvert = false;
                foreach (Cell ouvertCell in ouvert)
                {
                    if (voisin == ouvertCell)
                    {
                        inOuvert = true;
                    }
                }
                if (inOuvert == false)
                {
                    if (voisin.HCost <= nextStep.HCost)
                    {
                        nextStep = voisin;
                    }
                }
                
            }  else if (voisin.FCost < nextStep.FCost)
            {

                bool inOuvert = false;
                foreach (Cell ouvertCell in ouvert)
                {
                    if (voisin == ouvertCell)
                    {
                        inOuvert = true;
                    }
                }
                if (inOuvert == false)
                {
                    nextStep = voisin;
                }
                
            }
        }

        currentPos = nextStep;
        ouvert.Add(currentPos);
    }

    public void CheckIfArrived()
    {
        if(currentPos.Position == Arrive.Position)
        {
            Fini = true;
        }
    }
}
