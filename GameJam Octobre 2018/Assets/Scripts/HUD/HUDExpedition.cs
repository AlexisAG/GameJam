using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDExpedition : MonoBehaviour {

    [SerializeField] Color BackgroundColor = Color.grey;
    public float time2;
    public float Hz;
    public bool visible;
    public bool start;
    public bool m_enable;

    public int frequence = 6;
    int MAX_frequence;
    int pas;
    int duree;

    string Sfrequance;
    string SMAX_frequence;
    string Spas;
    string Sduree;

    float SliderMAX_frequence;
    float Sliderpas;
    float Sliderduree;

    Rect rectangle;
    public float size;

    Texture2D BackgroundTexture;

    Texture2D BackgroundTexture2;

    void Start()
    {
        BackgroundTexture = new Texture2D(1, 1);
        BackgroundTexture.SetPixel(0, 0, BackgroundColor);
        BackgroundTexture.Apply();

        size = gameObject.transform.localScale.x;

        start = false;

        SliderMAX_frequence = MAX_frequence;
        Sliderpas = pas;
        Sliderduree = duree;

        visible = true;

        time2 = 0;
        frequence = 6;
        //Show();
    }

    void OnGUI()
    {
        GUI.skin.box.normal.background = BackgroundTexture2;

        if (m_enable)
        {
            GUI.skin.box.normal.background = BackgroundTexture;

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height / 3), GUIContent.none);


            rectangle = new Rect(10, 0, Screen.width - 20, 20);
            GUI.Box(rectangle, "MAX_frequence");
            rectangle.y += 20;
            SliderMAX_frequence = (int)GUI.HorizontalSlider(rectangle, SliderMAX_frequence, 0, 120);

            rectangle.y += 10;
            GUI.Box(rectangle, "pas");
            rectangle.y += 20;
            Sliderpas = (int)GUI.HorizontalSlider(rectangle, Sliderpas, 0, 10);

            rectangle.y += 10;
            GUI.Box(rectangle, "duree");
            rectangle.y += 20;
            Sliderduree = (int)GUI.HorizontalSlider(rectangle, Sliderduree, 1, 20);

            rectangle.y += 10;
            GUI.Box(rectangle, "Taille");
            rectangle.y += 20;
            size = GUI.HorizontalSlider(rectangle, size, 0, 8);
            if (!start) { gameObject.transform.localScale = new Vector3(size, size, 1); }



        }

    }
    void FixedUpdate()
    {
        /*if (Input.GetKeyDown(m_enableKey))
        {
            m_enable = !m_enable;
        }*/

        time2 += Time.deltaTime;
        Hz = 1f / frequence;
        if (visible == true)
        {
            if (time2 > Hz)
            {
                //Hide();
            }
        }
        else
        {
            if (time2 > Hz)
            {
                //Show();
            }
        }
        

    }
    public void SetEnabledTrue()
    {
        m_enable = true;
    }


}
