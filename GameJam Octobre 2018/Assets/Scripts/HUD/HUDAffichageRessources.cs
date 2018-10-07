using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDAffichageRessources : MonoBehaviour {

    public Text infosInventaire;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update () {
        infosInventaire.text = "Bois : " + Inventaire.Instance.qteBois.ToString() + "\nPierre : " + Inventaire.Instance.qtePierre.ToString() + "\nMétal : " + Inventaire.Instance.qteMetal.ToString() + "\nNourriture : " + Inventaire.Instance.qteNourriture.ToString();
	}
}