using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addUnité : MonoBehaviour {

    public GameObject itemTemplate;
    public Font fontMessage;
    public GameObject content;
    public GameObject prefabBut;
    public GameObject scrollBack;
    private Soldat soldat;
    private addUnité refSoldat;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RecruteUnite()
    {
        refSoldat = this.GetComponent<addUnité>();
        CampementData.Instance.soldats.Add(refSoldat.soldat);
        GameObject parent = this.transform.parent.gameObject;
        Destroy(parent);
        print("Soldat : \n");
        foreach(Soldat sol in CampementData.Instance.soldats)
        {
            print(sol);
        }
    }
    public void addUniter()
    {
        scrollBack.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            
            Soldat unite = new Soldat(Random.Range(0, 4));
            string texto = unite.ToString();
            var copy = Instantiate(itemTemplate);;
            GameObject but = (GameObject)Instantiate(prefabBut);
            refSoldat = but.GetComponent<addUnité>();
            refSoldat.soldat = unite;
            GameObject newText = new GameObject("text", typeof(RectTransform));
            RectTransform rt = newText.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(232.5f, 149.3f);
            Text newTextComp = newText.AddComponent<Text>();
            newTextComp.text = texto;
            newTextComp.font = fontMessage;
            newTextComp.color = Color.green;
            newTextComp.fontSize = 16;
            newTextComp.transform.parent = copy.transform;
            newText.transform.position = new Vector3(0.0f, 26.5f, 0.0f);
            newText.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            but.transform.parent = copy.transform;
            but.transform.position = new Vector3(0.0f, -86.29999f, 0.0f);
            but.transform.localPosition = new Vector3(0.0f, -86.29999f, 0.0f);
            copy.transform.parent = content.transform;
        }
        this.gameObject.SetActive(false);
    }   
    }
