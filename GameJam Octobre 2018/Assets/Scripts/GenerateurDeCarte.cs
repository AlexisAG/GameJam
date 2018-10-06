using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeCarte : MonoBehaviour {
    public int xSize;

    public int ySize;

    public int season;

    public int TypeMission;

    //Temporaire
    [SerializeField]
    private GameObject joueur;

    public int nbPersoJoueur;

    public int nbPersoEnnemie;

    private List<Vector2> JoueurSpawnPos = new List<Vector2>();

    private Dictionary<Vector2Int, Terrain> tableauterrain = new Dictionary<Vector2Int, Terrain>();

    private Objectif objectifMission;

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

    public Objectif ObjectifMission
    {
        get
        {
            return objectifMission;
        }

        set
        {
            objectifMission = value;
        }
    }


    // Use this for initialization
    void Start () {
        float now = Time.realtimeSinceStartup;
        GenererLaCarte();
        PlacerObjectif();
        PlacerJoueur();
        PlacerEnnemi();
        Debug.Log("temps génération : " + (Time.realtimeSinceStartup - now) + " Secondes ");
    }

	// Update is called once per frame
	void Update () {
		
	}


    private void GenererLaCarte()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {

                tableauterrain.Add(new Vector2Int(i, j), new Terrain(AleatoireDesCases(i, j), i, j, Season));
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
            obstacleProbabilite = 15;
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

    private void PlacerObjectif()
    {
        int xAleatoireObtenu = Mathf.FloorToInt(Random.Range((XSize / 5)+2, (XSize/10)+2));
        int yAleatoireObtenu = Mathf.FloorToInt(Random.Range((YSize / 5)+2, (YSize/10)+2));
        if(tableauterrain[new Vector2Int(xAleatoireObtenu,yAleatoireObtenu)].TypeCase == 1)
        {
            tableauterrain[new Vector2Int(xAleatoireObtenu, yAleatoireObtenu)].IsFree = false;
            ObjectifMission = new Objectif(xAleatoireObtenu, yAleatoireObtenu, TypeMission);
        } else
        {
            int typeCase = 0;
            for(int i= -1; i<=1  && typeCase != 1;i++)
            {
                for (int j = -1; j <= 1 && typeCase != 1; j ++)
                {
                    if(tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree == true)
                    {
                        typeCase = 1;
                        tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree = false;
                        Debug.Log("Putain tu es free tes grands morts : " + tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree);
                        ObjectifMission = new Objectif(xAleatoireObtenu + i, yAleatoireObtenu + j, TypeMission);
                    }
                }
            }
        }
    }

    private void PlacerJoueur()
    {
        Debug.Log("Début placer joueur");
        JoueurSpawnPos = new List<Vector2>();
        int xAleatoireObtenu = Mathf.FloorToInt(Random.Range(XSize-(XSize / 10) - 2, XSize-(XSize / 5) - 2));
        int yAleatoireObtenu = Mathf.FloorToInt(Random.Range(YSize-(YSize / 10) - 2, YSize-(YSize / 5) - 2));

        int nbSpawn = nbPersoJoueur;

        for (int i = -1; i <= 1 && nbSpawn > 0; i++)
        {
            for (int j = -1; j <= 1 && nbSpawn > 0; j++)
            {
                Debug.Log("Tentative placement personnage");
                if (tableauterrain[new Vector2Int(xAleatoireObtenu + i, yAleatoireObtenu + j)].IsFree == true)
                {
                    nbSpawn--;
                    JoueurSpawnPos.Add(new Vector2(xAleatoireObtenu + i, yAleatoireObtenu + j));
                    Debug.Log("Je place un personnage");
                    Instantiate(joueur, new Vector3(xAleatoireObtenu + i, 0.5f, yAleatoireObtenu + j), Quaternion.identity);
                }
            }
        }
    }

    private void PlacerEnnemi()
    {
        int nbSpawn = nbPersoEnnemie;
        for (int i = -2; i <= 2 && nbSpawn > 0; i++)
        {
            for (int j = -2; j <= 2 && nbSpawn > 0; j++)
            {
                Debug.Log("Tentative placement personnage");
                if (tableauterrain[new Vector2Int((int)ObjectifMission.XPos + i, (int)ObjectifMission.YPos + j)].IsFree == true)
                {
                    Debug.Log("Is free : " + tableauterrain[new Vector2Int((int)ObjectifMission.XPos + i, (int)ObjectifMission.YPos + j)].IsFree);
                    nbSpawn--;
                    JoueurSpawnPos.Add(new Vector2((int)ObjectifMission.XPos + i, (int)ObjectifMission.YPos + j));
                    Debug.Log("Je place un personnage");
                    Instantiate(joueur, new Vector3((int)ObjectifMission.XPos + i, 0.5f, (int)ObjectifMission.YPos + j), Quaternion.identity);
                }
            }
        }
    }


}
