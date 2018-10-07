using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeCarte : MonoBehaviour {
    public int xSize;

    public int ySize;

    public int season;

    public int nbObjectif;

    public Mission.TypeMission TypeMission;

    public List<GameObject> CombatantSpawne = new List<GameObject>();

    //Temporaire
    public GameObject joueur, ennemi;

    private List<Vector2> JoueurSpawnPos = new List<Vector2>();

    private Dictionary<Vector2Int, Terrain> tableauterrain = new Dictionary<Vector2Int, Terrain>();

    public List<Objectif> objectifsMission = new List<Objectif>();

    public int XSize
    {
        get
        {
            return xSize;
        }

        set
        {
            xSize = value;
        }
    }

    public int YSize
    {
        get
        {
            return ySize;
        }

        set
        {
            ySize = value;
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

    public Dictionary<Vector2Int, Terrain> Tableauterrain
    {
        get
        {
            return tableauterrain;
        }

        set
        {
            tableauterrain = value;
        }
    }


    // Use this for initialization
    void Start () {

    }

	// Update is called once per frame
	void Update () {
		
	}

    public void GenererLaMission()
    {
        nbObjectif = HUDDetailMission.Mission.GetNbObjectif();
        float now = Time.realtimeSinceStartup;
        GenererLaCarte();
        PlacerObjectifs();
        PlacerJoueur();
        PlacerEnnemi();
        Debug.Log("temps génération : " + (Time.realtimeSinceStartup - now) + " Secondes ");
    }


    private void GenererLaCarte()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {

                Tableauterrain.Add(new Vector2Int(i, j), new Terrain(AleatoireDesCases(i, j), i, j, Season));
            }
        }
    }

    private int AleatoireDesCases(int xPos, int yPos)
    {
        int typeCase;
        int aucunSolProbabilte;
        int obstacleProbabilite;
        if(xPos < 2 || yPos < 2 || xPos > XSize - 2 || yPos > YSize - 2)
        {
            aucunSolProbabilte = 0;
            obstacleProbabilite = 300;
        } else
        {
            aucunSolProbabilte = 0;
            obstacleProbabilite = 10;
        }

        int aleatoireObtenu = Mathf.FloorToInt( Random.Range(0, 1000));

        if(aleatoireObtenu <= obstacleProbabilite)
        {
            typeCase = 2;
        } else if (aleatoireObtenu <= obstacleProbabilite + aucunSolProbabilte)
        {
            typeCase = 0;
        } else
        {
            typeCase = 1;
        }


        return typeCase;
    }

    private void PlacerObjectifs()
    {
        
        for(int k=0; k<nbObjectif;k++)
        {
            int xAleatoireObtenu = Mathf.FloorToInt(Random.Range( 3, XSize - XSize/ 5 - 2 ));
            int yAleatoireObtenu = Mathf.FloorToInt(Random.Range( 3, YSize - XSize / 5 - 2));

            if (Tableauterrain[new Vector2Int(xAleatoireObtenu, yAleatoireObtenu)].TypeCase == 1)
            {
                Tableauterrain[new Vector2Int(xAleatoireObtenu, yAleatoireObtenu)].IsFree = false;
                objectifsMission.Add(new Objectif(xAleatoireObtenu, yAleatoireObtenu, (int)TypeMission));
                nbObjectif--;
            }
            else
            {
                int typeCase = 0;
                for (int i = -1; i <= 1 && typeCase != 1; i++)
                {
                    for (int j = -1; j <= 1 && typeCase != 1; j++)
                    {
                        if (Tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree == true)
                        {
                            typeCase = 1;
                            Tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree = false;
                            nbObjectif--;
                        }
                    }
                }
            }
        }
        if(nbObjectif > 0 )
        {
            PlacerObjectifs();
        }
        
    }

    private void PlacerJoueur()
    {
        JoueurSpawnPos = new List<Vector2>();
        int xAleatoireObtenu = Mathf.FloorToInt(Random.Range(XSize-(XSize / 10) - 2, XSize-(XSize / 5) - 2));
        int yAleatoireObtenu = Mathf.FloorToInt(Random.Range(YSize-(YSize / 10) - 2, YSize-(YSize / 5) - 2));

        int nbSpawn = HUDDetailMission.Mission.Soldats.Count;

        for (int i = -1; i <= 1 && nbSpawn > 0; i++)
        {
            for (int j = -1; j <= 1 && nbSpawn > 0; j++)
            {
                if (Tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree == true)
                {
                    nbSpawn--;
                    JoueurSpawnPos.Add(new Vector2(xAleatoireObtenu + i, yAleatoireObtenu + j));
                    CombatantSpawne.Add(Instantiate(joueur, new Vector3(xAleatoireObtenu + i, 0.5f, yAleatoireObtenu + j), Quaternion.identity));
                    
                }
            }
        }
    }

    private void PlacerEnnemi()
    {
        int nbSpawn = HUDDetailMission.Mission.Ennemis.Count;
        int objectif = 0;
        for (int i = -1; i <= 1 && nbSpawn > 0; i++)
        {
            for (int j = -1; j <= 1 && nbSpawn > 0; j++)
            {
                if (Tableauterrain[new Vector2Int((int)objectifsMission[objectif].XPos + i, (int)objectifsMission[objectif].YPos + j)].IsFree == true)
                {
                    nbSpawn--;
                    JoueurSpawnPos.Add(new Vector2((int)objectifsMission[objectif].XPos + i, (int)objectifsMission[objectif].YPos + j));
                    CombatantSpawne.Add(Instantiate(ennemi, new Vector3((int)objectifsMission[objectif].XPos + i, 0.5f, (int)objectifsMission[objectif].YPos + j), Quaternion.identity));
                    objectif++;
                    if(objectif > objectifsMission.Count - 1 )
                    {
                        objectif = 0;
                    }
                }
            }
        }
    }


}
