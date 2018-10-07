using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDSelectionSoldat : MonoBehaviour {

    public GameObject refHUD, persoPrefab, content;
    public Texture Assassin, Eclaireur, Guerrier, Sniper;
    private List<Soldat> soldats = new List<Soldat>();

    
    private void Start()
    {

        int x = -100;

        for (int i = 0; i < CampementData.Instance.soldats.Count; i++)
        {
            x += 150;
            GameObject temp = Instantiate<GameObject>(persoPrefab, content.transform);
            temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, -50);

            temp.GetComponentsInChildren<Text>().ToList<Text>().ForEach(text =>
            {
                switch (text.name)
                {
                    case "classe":
                        text.text += CampementData.Instance.soldats[i].GetClasse();
                        break;
                    case "niveau":
                        text.text += CampementData.Instance.soldats[i].GetTypeCombattant().NiveauCombattant;
                        break;
                    case "dommage":
                        text.text += CampementData.Instance.soldats[i].GetTypeCombattant().DegatsCombattant;
                        break;
                    case "pointAction":
                        text.text += CampementData.Instance.soldats[i].GetTypeCombattant().PaCombattant;
                        break;
                    case "mouvementPoint":
                        text.text += CampementData.Instance.soldats[i].GetTypeCombattant().MpaCombattant;
                        break;
                    case "distance":
                        text.text += CampementData.Instance.soldats[i].GetTypeCombattant().AttackRangeCombattant;
                        break;
                }
            });

            switch (CampementData.Instance.soldats[i].GetClasse())
            {
                    case "Assassin":
                        temp.GetComponentInChildren<RawImage>().texture = Assassin;
                        break;
                    case "Eclaireur":
                        temp.GetComponentInChildren<RawImage>().texture = Eclaireur;
                        break;
                    case "Guerrier":
                        temp.GetComponentInChildren<RawImage>().texture = Guerrier;
                        break;
                    case "Sniper":
                        temp.GetComponentInChildren<RawImage>().texture = Sniper;
                        break;
            }

            Button tempBtn = temp.GetComponentInChildren<Button>();
            int paramDelegate = i;
            tempBtn.onClick.AddListener(delegate { SelectionUnite(paramDelegate, ref tempBtn); });

        }
    }

    private void SelectionUnite (int index, ref Button btn)
    {
        bool isNew = false;
        if(soldats.Count < 4)
        {
            if (soldats.IndexOf(CampementData.Instance.soldats[index]) == -1)
            {
                btn.GetComponentInChildren<Text>().text = "Deselectionner";
                Color color = btn.GetComponent<Image>().color = Color.green;
                if (soldats.Count >= 4)
                    content.GetComponentsInChildren<Button>().Where(button => button.GetComponentInChildren<Text>().text == "Sélectionner").ToList<Button>().ForEach(btnTemp => btnTemp.enabled = false);
                isNew = true;
                soldats.Add(CampementData.Instance.soldats[index]);
                Debug.Log(soldats[0].GetClasse());
            }
            else
            {
                btn.GetComponentInChildren<Text>().text = "Selectionner";
                Color color = btn.GetComponent<Image>().color = Color.white;
                soldats.RemoveAt(soldats.IndexOf(CampementData.Instance.soldats[index]));
            }

        }
        else
            content.GetComponentsInChildren<Button>().Where(button => button.GetComponentInChildren<Text>().text == "Sélectionner").ToList<Button>().ForEach(btnTemp => btnTemp.enabled = false);

        if (soldats.IndexOf(CampementData.Instance.soldats[index]) != -1 && !isNew)
        {
            btn.GetComponentInChildren<Text>().text = "Selectionner";
            Color color = btn.GetComponent<Image>().color = Color.white;
            soldats.RemoveAt(soldats.IndexOf(CampementData.Instance.soldats[index]));
        }

    }

    public void RetourOnClick()
    {
        soldats = new List<Soldat>();
        HUDDetailMission.Mission = null;
        refHUD.SetActive(true);
        gameObject.SetActive(false);
    }
    public void AccepterOnClick()
    {
        HUDDetailMission.Mission.Soldats = soldats;
        SceneManager.LoadScene("Mission", LoadSceneMode.Single);

    }
}
