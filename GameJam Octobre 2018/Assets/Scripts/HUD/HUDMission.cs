using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDMission : MonoBehaviour {

    public List<GameObject> MissionsPins;

	// Use this for initialization
	void Awake () {
        CampementData.Instance.soldats.Add(new Soldat(TypeCombattant.nomTypeCombattant.Assassin));
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();
        GenerationMissionDefense.GenerateMission();

        for (int i = 0; i < MissionsPins.Count; i++)
            MissionsPins[i].transform.localPosition = CampementData.Instance.missionsDisponible[i].GetPositionOnMap();
                    
    }
	
	public void CheckMission(int index)
    {
        Debug.Log(CampementData.Instance.missionsDisponible[index]);
    }
}
