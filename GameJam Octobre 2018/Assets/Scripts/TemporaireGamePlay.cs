using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaireGamePlay : MonoBehaviour {

    private AStar myAstar;

    private Vector2 positionStart;
    private Vector2 positionEnd;

    public GameObject ping;

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
        myAstar = new AStar(new Vector2(5, 5), new Vector2(10, 10));


    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 MousePoint = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                MousePoint = hit.point;
            }
            PositionStart = new Vector2(Mathf.Floor(MousePoint.x), Mathf.Floor(MousePoint.z));
            Debug.Log(MousePoint);
            Debug.Log(PositionStart);
            Instantiate(ping, new Vector3(PositionStart.x, 0.5f, PositionStart.y), Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 MousePoint = new Vector3();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                MousePoint = hit.point;
            }
            PositionEnd = new Vector2(Mathf.Floor(MousePoint.x), Mathf.Floor(MousePoint.z));
            Debug.Log(MousePoint);
            Debug.Log(PositionStart);
            Instantiate(ping, new Vector3(PositionEnd.x, 0.5f, PositionEnd.y), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float now = Time.realtimeSinceStartup;
            myAstar.ResetAStar(PositionStart, PositionEnd);
            List<Vector2> results =  myAstar.CalculerTrajet();
            Debug.Log("temps AStar : " + (Time.realtimeSinceStartup - now) + " Secondes ");
            foreach (Vector2 result in results)
            {
                Instantiate(ping, new Vector3(result.x, 0.5f, result.y), Quaternion.identity);
            }
            Debug.Log("temps AStar avec affichage : " + (Time.realtimeSinceStartup - now) + " Secondes ");

        }

        
    }
}
