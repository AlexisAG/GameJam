using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPersonnage : MonoBehaviour {

    private AStar gestionnaireTrajet;

    public bool monTour = false;
    public bool unJoueurControle = false;
    private bool isCalculating = false;

    private Vector2 positionStart;
    private Vector2 positionEnd;

    public int nomDuTypeDeCombattant;

    private Soldat statSoldat;

    private Ennemi statEnnemi;

    public TypeCombattant statCombatant;


    public GameObject road;
    public GameObject ping;


    public List<GameObject> trajetObject = new List<GameObject>();
    public GameObject startObjectPos;
    public GameObject endObjectPos;
    public GenerateurDeCarte generateurDeCarte;

    public List<Vector2> trajet = new List<Vector2>();
    public int coutTrajet;
    public int paDispo;

    public bool enTrajet = false;
    public float speed = 5;

    public Vector2 PositionStart
    {
        get
        {
            return positionStart;
        }

        set
        {
            positionStart = value;
        }
    }

    public Vector2 PositionEnd
    {
        get
        {
            return positionEnd;
        }

        set
        {
            positionEnd = value;
        }
    }

    public Soldat StatSoldat
    {
        get
        {
            return statSoldat;
        }

        set
        {
            statSoldat = value;
        }
    }

    public Ennemi StatEnnemi
    {
        get
        {
            return statEnnemi;
        }

        set
        {
            statEnnemi = value;
        }
    }

    // Use this for initialization
    void Start () {
        PositionStart = new Vector2(Mathf.Floor(this.transform.position.x + 0.5f), Mathf.Floor(this.transform.position.z + 0.5f));
        gestionnaireTrajet = new AStar();
        generateurDeCarte = GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>();
        generateurDeCarte.Tableauterrain[new Vector2Int((int) PositionStart.x, (int) PositionStart.y)].IsFree = false;
        if(unJoueurControle)
        {
            generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnSoldatDessus = true;
            generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].SoldatDessus = gameObject;
        } else
        {
            generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnEnnemyDessus = true;
            generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].EnnemyDessus = gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(monTour)
        {
            if(!unJoueurControle )
            {
                FinDeTour();
                GameObject.Find("CombatManager").GetComponent<CombatManager>().changementTour();
            }
            if(!enTrajet && paDispo <= 0)
            {
                FinDeTour();
                GameObject.Find("CombatManager").GetComponent<CombatManager>().changementTour();
            }
            if (Input.GetMouseButtonDown(1) && !enTrajet)
            {
                PositionStart = new Vector2(Mathf.Floor(this.transform.position.x + 0.5f), Mathf.Floor(this.transform.position.z + 0.5f));
                GameObject.Destroy(endObjectPos);
                Debug.Log(PositionEnd);
                ShowTrajet(true);
                
            }

            if (Input.GetMouseButtonDown(0) && !enTrajet)
            {
                PositionStart = new Vector2(Mathf.Floor(this.transform.position.x + 0.5f), Mathf.Floor(this.transform.position.z + 0.5f));
                GameObject.Destroy(endObjectPos);
                Debug.Log(PositionEnd);
                ShowTrajet(false);

            }

            if (enTrajet)
            {
                SuivreChemin();

            }

        }
        
    }

    public void CreateStatCombatant(int i, int nbSoldat)
    {
        if (unJoueurControle)
        {
            StatSoldat = CampementData.Instance.soldats[i];
            statCombatant = StatSoldat.combattant;
        }
        else
        {
            StatEnnemi = HUDDetailMission.Mission.Ennemis[i-nbSoldat];
            statCombatant = StatEnnemi.combattant;
        }
    }

    private void GenerateChemin(bool FaireChemin)
    {
        isCalculating = true;


        for (int i = 0; i < trajetObject.Count; i++)
        {
            GameObject.Destroy(trajetObject[i]);
        }
        trajetObject = new List<GameObject>();
        float now = Time.realtimeSinceStartup;
        gestionnaireTrajet.ResetAStar(PositionStart, PositionEnd);
        List<Vector2> results = gestionnaireTrajet.CalculerTrajet();
        Debug.Log("temps AStar : " + (Time.realtimeSinceStartup - now) + " Secondes ");
        for (int i = results.Count-1; i >= 0 ; i--)
        {
            if (i + 1 != results.Count)
            {
                if (results[i + 1].x == results[i].x)
                {
                    trajetObject.Add(Instantiate(road, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.Euler(0, 90, 0)));
                }
                else if (results[i + 1].y == results[i].y)
                {
                    trajetObject.Add(Instantiate(road, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.identity));
                }
            }
        }
        coutTrajet = results.Count;
        int coutEnPa = Mathf.CeilToInt(coutTrajet / statCombatant.MpaCombattant) + 1;
        if (FaireChemin)
        {
            if (paDispo >= coutEnPa)
            {
                generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].IsFree = true;
                if (unJoueurControle)
                {
                    generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnSoldatDessus = false;
                    generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].SoldatDessus = null;
                }
                else
                {
                    generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnEnnemyDessus = false;
                    generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].EnnemyDessus = null;
                }
                paDispo -= coutEnPa;
                trajet.Add(PositionEnd);
                trajet.AddRange( results);
                enTrajet = true;
                isCalculating = false;
                Debug.Log("temps AStar avec affichage : " + (Time.realtimeSinceStartup - now) + " Secondes ");
            }
            else
            {
                Debug.Log("Mouvement impossible pas assez de pa");
            }
        } else
        {
            Debug.Log("Nb PA dispo : " + paDispo);
            Debug.Log("Nb Mouvement : " + coutTrajet + " cout en PA : " + coutEnPa);
        }
        
        
    }

    private Vector2 PointToWorld()
    {
        Vector3 MousePoint = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MousePoint = hit.point;
        }
        return new Vector2(Mathf.Floor(MousePoint.x + 0.5f), Mathf.Floor(MousePoint.z + 0.5f));
    }

    private void ShowTrajet(bool FaireChemin)
    {
        Vector2 MousePos = PointToWorld();
        if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].IsFree)
        {
            Debug.Log("je passe");
            PositionEnd = MousePos;
            GenerateChemin(FaireChemin);
        }
        else
        {
            if(unJoueurControle)
            {
                if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnEnnemyDessus)
                {
                    if(CheckPeutAttaquer(new Vector2Int((int)MousePos.x, (int)MousePos.y)))
                    {
                        Debug.Log("Peux attaquer ennemy");
                        if(FaireChemin)
                        {
                            TypeCombattant ennemy = generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus.GetComponent<MouvementPersonnage>().statCombatant;
                            Debug.Log("Avant : Vie enemy : " + ennemy.HpCombattant);
                            StatSoldat.AttaqueAdversaire(ennemy);
                            if(ennemy.HpCombattant<=0)
                            {
                                Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
                                GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.RemoveAt(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus));
                                GameObject.Destroy(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus);
                                Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
                            }
                            Debug.Log("Après : Vie enemy : " + ennemy.HpCombattant);
                        }
                    }
                } else if(GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnSoldatDessus)
                {
                    Debug.Log("Un allié");
                } else
                {
                    Debug.Log("Impossible obstacle");
                }
            } else
            {
                if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnEnnemyDessus)
                {
                    Debug.Log("Un allié");   
                }
                else if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnSoldatDessus)
                {
                    Debug.Log("Peut attaquer");
                } else
                {
                    Debug.Log("Impossible obstacle");
                }
            }
            
            
        }
    }

   /* private void RapprocherPourAttaquer(Vector2Int ennemyPos, bool FaireChemin)
    {
        List<Vector2Int> casesVoisinEnnemy = new List<Vector2Int>();
        if(GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(ennemyPos.x-1, ennemyPos.y)].IsFree)
        {
            casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x - 1, ennemyPos.y));
        } else if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(ennemyPos.x + 1, ennemyPos.y)].IsFree)
        {
            casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x + 1, ennemyPos.y));
        } else if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(ennemyPos.x, ennemyPos.y-1)].IsFree)
        {
            casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x, ennemyPos.y-1));
        } else if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(ennemyPos.x , ennemyPos.y+1)].IsFree)
        {
            casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x, ennemyPos.y+1));
        }

        float bestDist = 10000000000000000000;
        Vector2Int bestCase = new Vector2Int();
        foreach(Vector2Int caseVoisinEnnemy in casesVoisinEnnemy)
        {
            if(Vector2.Distance(positionStart,(Vector2)caseVoisinEnnemy) < bestDist)
            {
                bestDist = Vector2.Distance(positionStart, (Vector2)caseVoisinEnnemy);
                bestCase = caseVoisinEnnemy;
            }
        }

        PositionEnd = (Vector2)bestCase;
        GenerateChemin(FaireChemin);
    }*/

    private bool CheckPeutAttaquer(Vector2Int ennemyPos)
    {
        if (statCombatant.AttackRangeCombattant == 1)
        {
            if(CheckSiVoisin(ennemyPos))
            {
                return true;
            }
        }else
        {
            if (Mathf.Abs(Vector2Int.Distance(ennemyPos, new Vector2Int(Mathf.FloorToInt(PositionStart.x) ,  Mathf.FloorToInt(PositionStart.y)))) <= statCombatant.AttackRangeCombattant)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckSiVoisin(Vector2Int ennemyPos)
    {
        List<Vector2Int> casesVoisinEnnemy = new List<Vector2Int>();

        casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x - 1, ennemyPos.y));

        casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x + 1, ennemyPos.y));
 
        casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x, ennemyPos.y - 1));

        casesVoisinEnnemy.Add(new Vector2Int(ennemyPos.x, ennemyPos.y + 1));

        bool estVoisin = false;
        foreach(Vector2Int caseVoisin in casesVoisinEnnemy)
        {
            if(caseVoisin.x == Mathf.FloorToInt(PositionStart.x) && caseVoisin.y == Mathf.FloorToInt(PositionStart.y))
            {
                estVoisin = true;
            }
        }
        return estVoisin;
    }

    private void SuivreChemin()
    {
        if(trajet.Count > 0)
        {
            if(this.transform.position.x < trajet[trajet.Count-1].x && Mathf.Abs( this.transform.position.x - trajet[trajet.Count - 1].x )> 0.05f)
            {
                this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            } else if (this.transform.position.x > trajet[trajet.Count - 1].x && Mathf.Abs(this.transform.position.x - trajet[trajet.Count - 1].x) > 0.05f)
            {
                this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
            }

            if (this.transform.position.z < trajet[trajet.Count - 1].y && Mathf.Abs(this.transform.position.z - trajet[trajet.Count - 1].y) > 0.05f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
            }
            else if (this.transform.position.z > trajet[trajet.Count - 1].y && Mathf.Abs(this.transform.position.z + trajet[trajet.Count - 1].y) > 0.05f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
            }

            if(Vector3.Magnitude(this.transform.position - new Vector3(trajet[trajet.Count - 1].x, 0.5f,trajet[trajet.Count - 1].y)) < 0.1f)
            {
                trajet.RemoveAt(trajet.Count - 1);
                if(trajet.Count == 0)
                {
                    for (int i = 0; i < trajetObject.Count; i++)
                    {
                        GameObject.Destroy(trajetObject[i]);
                    }
                    trajetObject = new List<GameObject>();

                    PositionStart = new Vector2(Mathf.Floor(this.transform.position.x + 0.5f), Mathf.Floor(this.transform.position.z + 0.5f));
                    generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].IsFree = false;
                    if (unJoueurControle)
                    {
                        generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnSoldatDessus = true;
                        generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].SoldatDessus = gameObject;
                    }
                    else
                    {
                        generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].UnEnnemyDessus = true;
                        generateurDeCarte.Tableauterrain[new Vector2Int((int)PositionStart.x, (int)PositionStart.y)].EnnemyDessus = gameObject;
                    }
                    enTrajet = false;
                }
            }
        } else
        {
            for (int i = 0; i < trajetObject.Count; i++)
            {
                GameObject.Destroy(trajetObject[i]);
            }
            trajetObject = new List<GameObject>();
            enTrajet = false;

        }
        
    }

    public void CommencerSonTour()
    {
        coutTrajet = 0;
        paDispo = statCombatant.PaCombattant;
        monTour = true;
    }

    public void FinDeTour()
    {
        for (int i = 0; i < trajetObject.Count; i++)
        {
            GameObject.Destroy(trajetObject[i]);
        }
        trajetObject = new List<GameObject>();
        monTour = false;
    }
}
