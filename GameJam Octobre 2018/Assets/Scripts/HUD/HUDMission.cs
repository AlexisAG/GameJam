using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDMission : MonoBehaviour {

    public List<GameObject> MissionsPins;
    public GameObject HudDetail;

	// Use this for initialization
	void Awake () {

        for (int i = 0; i < MissionsPins.Count; i++)
            MissionsPins[i].transform.localPosition = CampementData.Instance.missionsDisponible[i].GetPositionOnMap();
                    
    }
	
	public void CheckMission(int index)
    {
        HUDDetailMission.Mission = CampementData.Instance.missionsDisponible[index];
        HudDetail.gameObject.SetActive(true);
        HudDetail.GetComponent<HUDDetailMission>().DisplayMission();
    }

    public void GoBack()
    {
        gameObject.SetActive(false);
    }

}
