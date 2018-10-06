using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighlightOnMouse : MonoBehaviour {
    [SerializeField]
    private bool b_ActivateOnOver;
    [SerializeField]
    private bool b_ActivateOnClick;
    [SerializeField]
    private Color colorOnOver;
    [SerializeField]
    private Color colorOnClick;

    private bool isLit;
    private bool clicked;
    private Light objectLight;
    Ray detect;
    RaycastHit hit;


    public bool IsLit
    {
        get
        {
            return isLit;
        }

        set
        {
            isLit = value;
        }
    }

    public Light ObjectLight
    {
        get
        {
            return objectLight;
        }

        set
        {
            objectLight = value;
        }
    }

    public Color ColorOnClick
    {
        get
        {
            return colorOnClick;
        }

        set
        {
            colorOnClick = value;
        }
    }

    public Color ColorOnOver
    {
        get
        {
            return colorOnOver;
        }

        set
        {
            colorOnOver = value;
        }
    }

    public bool B_ActivateOnClick
    {
        get
        {
            return b_ActivateOnClick;
        }

        set
        {
            b_ActivateOnClick = value;
        }
    }

    public bool B_ActivateOnOver
    {
        get
        {
            return b_ActivateOnOver;
        }

        set
        {
            b_ActivateOnOver = value;
        }
    }

    public bool Clicked
    {
        get
        {
            return clicked;
        }

        set
        {
            clicked = value;
        }
    }

    // Use this for initialization
    void Start () {
        ObjectLight = GetComponentInChildren<Light>();
        if(ObjectLight==null)
        {
            ObjectLight = gameObject.AddComponent(typeof(Light)) as Light;
            ObjectLight.range = 5;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (IsLit)
        {
            detect = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(detect, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ObjectLight.intensity = 0;
                    IsLit = false;
                    Clicked = false;
                }
            }
        }
    }

    //is called upon entering in the collider
    void OnMouseEnter()
    {
        if (B_ActivateOnOver && !IsLit)
        {
            ObjectLight.color =ColorOnOver;
            ObjectLight.intensity = 10;
            IsLit = true;
        }
    }

    void OnMouseExit()
    {
        if (B_ActivateOnOver && isLit && !Clicked)
        {
            ObjectLight.intensity = 0;
            IsLit = false;
        }
    }

    void OnMouseDown()
    {
        if (B_ActivateOnClick)
        {
            ObjectLight.color =ColorOnClick;
            ObjectLight.intensity = 10;
            IsLit = true;
            Clicked = true;
        }
    }
}
