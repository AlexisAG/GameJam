using UnityEngine;

public class Inventaire : MonoBehaviour
{

    //singleton
    private static Inventaire instance;
    public static Inventaire Instance { get { return instance; } }

    public int qtePierre;
    public int qteBois;
    public int qteMetal;
    public int qteNourriture;


    // Use this for initialization
    public void Start()
    {
        qtePierre = 50;
        qteBois = 50;
        qteMetal = 50;
        qteNourriture = 50;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
