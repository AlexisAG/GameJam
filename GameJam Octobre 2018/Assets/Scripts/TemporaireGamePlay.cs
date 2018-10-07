using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaireGamePlay : MonoBehaviour {

    private AStar myAstar;

    private bool isCalculating = false;

    private Vector2 positionStart;
    private Vector2 positionEnd;


    public GameObject road;
    public GameObject ping;

    public List<GameObject> trajetObject = new List<GameObject>();
    public GameObject startObjectPos;
    public GameObject endObjectPos;

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


    // Use this for initialization
    void Start () {
        myAstar = new AStar();


    }
	
	// Update is called once per frame
	void Update () {


		if(Input.GetMouseButtonDown(0))
        {
            GameObject.Destroy(startObjectPos);
            PositionStart = PointToWorld();
            Debug.Log(PositionStart);
            startObjectPos = Instantiate(ping, new Vector3(PositionStart.x, 0.5f, PositionStart.y), Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Destroy(endObjectPos);
            Debug.Log(PositionEnd);
            ShowTrajet();
            endObjectPos = Instantiate(ping, new Vector3(PositionEnd.x, 0.5f, PositionEnd.y), Quaternion.identity);
        }
        
    }

    private void GenerateChemin()
    {
        isCalculating = true;


        for (int i = 0; i < trajetObject.Count; i++)
        {
            GameObject.Destroy(trajetObject[i]);
        }
        trajetObject = new List<GameObject>();
        float now = Time.realtimeSinceStartup;
        myAstar.ResetAStar(PositionStart, PositionEnd);
        List<Vector2> results = myAstar.CalculerTrajet();
        Debug.Log("temps AStar : " + (Time.realtimeSinceStartup - now) + " Secondes ");
        for (int i = 0; i < results.Count; i++)
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
        isCalculating = false;
        Debug.Log("temps AStar avec affichage : " + (Time.realtimeSinceStartup - now) + " Secondes ");
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

    private void ShowTrajet()
    {
        Vector2 MousePos = PointToWorld();
        if(MousePos != PositionEnd)
        {
            if (GameObject.Find("GenerateurDeCarte").GetComponent<GenerateurDeCarte>().Tableauterrain[new Vector2Int ((int)MousePos.x, (int)MousePos.y)].IsFree)
            {
                Debug.Log("je passe");
                PositionEnd = MousePos;
                GenerateChemin();
            } else
            {
                Debug.Log("Impossible obstacle");
            }
            
        }
    }
}
