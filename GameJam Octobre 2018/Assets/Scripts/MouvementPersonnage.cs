using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private GameObject EnnemiFocus;

    public TypeCombattant statCombatant;


    public GameObject road;
    public GameObject roadGood;
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

    private string uiMessage;

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

    public string UiMessage
    {
        get
        {
            return uiMessage;
        }

        set
        {
            uiMessage = value;
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
                //FinDeTour();
                if(!enTrajet && paDispo > 0)
                {
                    ObtenirEntiteProche();
                    AllerSurEntite();
                }

                if (!enTrajet && paDispo <= 0)
                {
                    GameObject.Find("CombatManager").GetComponent<CombatManager>().changementTour();
                }

                if (enTrajet)
                {
                    SuivreChemin();

                } 
            } else
            {
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
        
    }

    public void CreateStatCombatant(int i, int nbSoldat)
    {
        if (unJoueurControle)
        {
            StatSoldat = HUDDetailMission.Mission.Soldats[i];
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
        bool BonChemin = false;
        int maxMouvement = paDispo * statCombatant.MpaCombattant;
        if(results.Count <= maxMouvement)
        {
            BonChemin = true;
        }
        for (int i = results.Count-1; i >= 0 ; i--)
        {
            if (i + 1 != results.Count)
            {
                if (results[i + 1].x == results[i].x)
                {
                    if(BonChemin)
                    {
                        trajetObject.Add(Instantiate(roadGood, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.Euler(0, 90, 0)));
                    } else
                    {
                        trajetObject.Add(Instantiate(road, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.Euler(0, 90, 0)));
                    }
                    
                }
                else if (results[i + 1].y == results[i].y)
                {
                    if (BonChemin)
                    {
                        trajetObject.Add(Instantiate(roadGood, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.identity));
                    }
                    else
                    {
                        trajetObject.Add(Instantiate(road, new Vector3(results[i].x + (results[i + 1].x - results[i].x) / 2, 0.5f, results[i].y + (results[i + 1].y - results[i].y) / 2), Quaternion.identity));
                    }
                    
                }
            }
        }
        coutTrajet = results.Count;
        int coutEnPa = Mathf.CeilToInt((float)coutTrajet / (float)statCombatant.MpaCombattant);
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
                UiMessage = "Mouvement impossible : pas assez de pa";
            }
        } else
        {
            Debug.Log("Nb PA dispo : " + paDispo);
            Debug.Log("Nb Mouvement : " + coutTrajet + "\n cout en PA : " + coutEnPa);
            UiMessage = "Nb Mouvement : " + coutTrajet + "\n coût en PA : " + coutEnPa;
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
        Debug.LogWarning("Mouse pos : " + MousePos);
        if(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain.ContainsKey( new Vector2Int((int)MousePos.x, (int)MousePos.y)) == true)
        {
            if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].IsFree)
            {
                Debug.Log("je passe");
                PositionEnd = MousePos;
                GenerateChemin(FaireChemin);
            }
            else
            {
                if (unJoueurControle)
                {
                    if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnEnnemyDessus)
                    {
                        if (CheckPeutAttaquer(new Vector2Int((int)MousePos.x, (int)MousePos.y)) && paDispo >= 1)
                        {
                            Debug.Log("Peux attaquer ennemy");
                            if (FaireChemin)
                            {
                                TypeCombattant ennemy = generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus.GetComponent<MouvementPersonnage>().statCombatant;
                                Debug.Log("Avant : Vie enemy : " + ennemy.HpCombattant);
                                StatSoldat.AttaqueAdversaire(ennemy);
                                UiMessage = statCombatant.DegatsCombattant + " dégats infligés. " + ennemy.HpCombattant + " hp restants.";
                                if (ennemy.HpCombattant <= 0)
                                {
                                    Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
                                    GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.RemoveAt(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus));
                                    GameObject.Destroy(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EnnemyDessus);
                                    Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
                                }
                                Debug.Log("Après : Vie enemy : " + ennemy.HpCombattant);
                                --paDispo;
                            }
                        }
                    }
                    else if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnSoldatDessus)
                    {
                        Debug.Log("Un allié");
                    }
                    else if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].EstUnObjectif)
                    {
                        if (CheckSiVoisin(new Vector2Int((int)MousePos.x, (int)MousePos.y)))
                        {
                            if (FaireChemin)
                            {
                                Debug.LogWarning(generateurDeCarte.objectifsMission.Count);
                                Debug.LogWarning(generateurDeCarte.objectifsMission.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].Objectif));
                                generateurDeCarte.objectifsMission.RemoveAt(generateurDeCarte.objectifsMission.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].Objectif));
                                GameObject.Destroy(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].Objectif.Mesh);
                                generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].IsFree = true;
                                Debug.LogWarning(generateurDeCarte.objectifsMission.Count);
                            }
                            else
                            {
                                Debug.Log("Objectif peut être ramassé.");
                            }
                        }
                        else
                        {
                            Debug.Log("Trop loin pour être ramassé.");
                        }
                    }
                    else
                    {
                        Debug.Log("Impossible obstacle");
                    }
                }
                else
                {
                    if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnEnnemyDessus)
                    {
                        Debug.Log("Un allié");
                    }
                    else if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)MousePos.x, (int)MousePos.y)].UnSoldatDessus)
                    {
                        Debug.Log("Peut attaquer");
                    }
                    else
                    {
                        Debug.Log("Impossible obstacle");
                    }
                }


            }
        } else
        {
            Debug.Log("Au dela de la map.");
        }
        
    }

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


    private void ObtenirEntiteProche()
    {
        float bestDistance = 100000000000;
        GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Where(combattant => combattant.GetComponent<MouvementPersonnage>().unJoueurControle).ToList<GameObject>().ForEach(joueur =>
        {
            if(Vector2.Distance(joueur.GetComponent<MouvementPersonnage>().PositionStart, PositionStart) < bestDistance)
            {
                bestDistance = Vector2.Distance(joueur.GetComponent<MouvementPersonnage>().PositionStart, PositionStart);
                EnnemiFocus = joueur;
            }
        });
   
    }
    
    private Vector2Int ChercherPositionVoisine()
    {
        List<Vector2Int> PositionVoisineLibre = new List<Vector2Int>();
        Vector2Int entPos = new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y);

        if(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(entPos.x + 1, entPos.y)].IsFree)
        {
            PositionVoisineLibre.Add(new Vector2Int(entPos.x + 1, entPos.y));
        }
        if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(entPos.x - 1, entPos.y)].IsFree)
        {
            PositionVoisineLibre.Add(new Vector2Int(entPos.x - 1, entPos.y));
        }
        if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(entPos.x , entPos.y + 1)].IsFree)
        {
            PositionVoisineLibre.Add(new Vector2Int(entPos.x, entPos.y + 1));
        }
        if (generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int(entPos.x , entPos.y - 1)].IsFree)
        {
            PositionVoisineLibre.Add(new Vector2Int(entPos.x, entPos.y - 1));
        }

        return PositionVoisineLibre[0];
    }

    private void AllerSurEntite()
    {
        
        if(CheckSiVoisin(new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y)))
        {
            LancerAttaque();
        } else
        {
            gestionnaireTrajet.ResetAStar(PositionStart, ChercherPositionVoisine());
            List<Vector2> results = gestionnaireTrajet.CalculerTrajet();

            if (results.Count < statCombatant.MpaCombattant * paDispo)
            {
                int coutEnPa = Mathf.CeilToInt((float)results.Count / (float)statCombatant.MpaCombattant);
                paDispo -= coutEnPa;
                //trajet.Add(PositionEnd);
                trajet.AddRange(results);
                enTrajet = true;
                isCalculating = false;
            }
            else
            {
                int nbCaseMax = statCombatant.MpaCombattant * paDispo;
                paDispo = 0;
                List<Vector2> tempTarjet = new List<Vector2>();
                //tempTarjet.Add(positionEnd);
                tempTarjet.AddRange(results);
                trajet = tempTarjet.Skip(tempTarjet.Count - nbCaseMax).Take(nbCaseMax).ToList<Vector2>();
                enTrajet = true;
                isCalculating = false;

            }
        }
        
    }

    private void LancerAttaque()
    {
        if(paDispo >= 1)
        {
            
            StatEnnemi.AttaqueAdversaire(EnnemiFocus.GetComponent<MouvementPersonnage>().statCombatant);
            UiMessage = statCombatant.DegatsCombattant + " dégats reçus. " + EnnemiFocus.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant + " hp restants.";
            if (EnnemiFocus.GetComponent<MouvementPersonnage>().statCombatant.HpCombattant <= 0)
            {
                Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
                CampementData.Instance.soldats.RemoveAt(CampementData.Instance.soldats.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y)].SoldatDessus.GetComponent<MouvementPersonnage>().statSoldat));
                GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.RemoveAt(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.IndexOf(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y)].SoldatDessus));
                generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y)].IsFree = true;
                GameObject.Destroy(generateurDeCarte.GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int((int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.x, (int)EnnemiFocus.GetComponent<MouvementPersonnage>().PositionStart.y)].SoldatDessus);
                ObtenirEntiteProche();
                Debug.LogWarning(GameObject.Find("CombatManager").GetComponent<CombatManager>().listeCombattant.Count);
            }
            --paDispo;
        }
        
        
    }


}
