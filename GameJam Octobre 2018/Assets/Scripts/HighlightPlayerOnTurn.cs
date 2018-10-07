using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPlayerOnTurn : MonoBehaviour {

    public Light ObjectLight;
    public Color myColor;
    public float myIntensity;
    public bool isLit;
    // Use this for initialization
    void Start () {
        /*ObjectLight = GetComponentInChildren<Light>();
        if (ObjectLight == null)
        {
            ObjectLight = gameObject.AddComponent(typeof(Light)) as Light;
            ObjectLight.range = 5;
        }*/
        ObjectLight.color = myColor;
        ObjectLight.intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Lit()
    {
        ObjectLight.intensity = myIntensity;
    }

    public void UnLit()
    {
        ObjectLight.intensity = 0;
    }
}
