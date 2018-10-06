using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMissionExploration {

    public static void GenerateMission()
    {
        Mission mission = new Mission(Mission.TypeMission.Recherche, (byte)Random.Range(3, 7), CreateLvlMission(),
                                        0, "La recherche du Graal", new Vector2Int(Random.Range(5, 20), Random.Range(5, 20)));
        mission.Ennemis = CreateEnnemi(mission.GetLvlMission());

        CampementData.Instance.missionsDisponible.Add(mission);
    }

    private static byte CreateLvlMission()
    {
        byte lvlMoyen = 0;

        for (int i = 0; i < CampementData.Instance.soldats.Count; i++)
            lvlMoyen += (byte)CampementData.Instance.soldats[i].GetLevel();

        return (byte)(lvlMoyen / CampementData.Instance.soldats.Count);
    }

    private static List<Ennemi> CreateEnnemi(byte lvl)
    {
        List<Ennemi> ennemis = new List<Ennemi>();
        /* TO DO  */
        return ennemis;
    }
}
