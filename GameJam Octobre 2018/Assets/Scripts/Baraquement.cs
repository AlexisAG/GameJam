using UnityEngine;
using UnityEngine.UI;

public class Baraquement : Batiment
{

    private int niveauDesNouvellesRecrues;
    public GameObject itemTemplate;
    public Font fontMessage;
    public GameObject content;
    public GameObject prefabBut;
    public GameObject scrollBack;
    private Soldat soldat;
    private Baraquement refSoldat;

    public int NiveauDesNouvellesRecrues
    {
        get
        {
            return niveauDesNouvellesRecrues;
        }

        set
        {
            niveauDesNouvellesRecrues = value;
        }
    }

    private void Start()
    {
        InitBatiment((GetType().ToString()));
        this.NiveauDesNouvellesRecrues = 1;
    }

    public override void Ameliorer()
    {
        if (UpgradePossible == true)
        {
            NiveauBatiment++;

            if (NiveauDesNouvellesRecrues < 10)
                NiveauDesNouvellesRecrues += 1;
            else
            {
                NiveauDesNouvellesRecrues = 10;
                print("Niveau des nouvelles recrues maximal atteint");
            }
            Nom = this.GetType().ToString() + " Niv. " + NiveauBatiment;
            ChangeRessourceUpgrade();
            PayerBatiment();
        }
    }

    public override string ToString()
    {
        return "Nom: " + this.Nom +
            ". Niveau Batiment: " + this.NiveauBatiment +
            ". estDispo: " + this.UpgradePossible +
            ". Cout: " + this.CoutEnRessources +
            ". Niveau armes et armures : " + this.NiveauDesNouvellesRecrues +
            ". Ressource pour upgrade : " + RessourcePourUpgrade;
    }

    public void AddUnite()
    {
        scrollBack.SetActive(true);
        for (int i = 0; i < 3; i++)
        {

            Soldat unite = new Soldat(Random.Range(0, 4));
            string texto = unite.ToString();
            var copy = Instantiate(itemTemplate); ;
            GameObject but = (GameObject)Instantiate(prefabBut);
            refSoldat = but.GetComponent<Baraquement>();
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

    public void RecruteUnite()
    {
        refSoldat = this.GetComponent<Baraquement>();
        CampementData.Instance.soldats.Add(refSoldat.soldat);
        GameObject parent = this.transform.parent.gameObject;
        Destroy(parent);
        print("Soldat : \n");
        foreach (Soldat sol in CampementData.Instance.soldats)
        {
            print(sol);
        }
    }
}
