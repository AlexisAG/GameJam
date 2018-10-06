using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationMissionSurvivant {

    public static void GenerateMission()
    {
        byte groupeSurvivant = (byte)Random.Range(3, 7);

        Mission mission = new Mission(Mission.TypeMission.Survivant, groupeSurvivant, CreateLvlMission(),
                                                       groupeSurvivant * 10, "Besoin de main d'oeuvre",
                                                       new Vector3(Random.Range(-250, 250), Random.Range(-250, 250)));
        mission.Ennemis = CreateEnnemi(mission.GetLvlMission());

        CampementData.Instance.missionsDisponible.Add(mission);
    }

    private static byte CreateLvlMission()
    {
        byte lvlMoyen = 0;

        for (int i = 0; i < CampementData.Instance.soldats.Count; i++)
            lvlMoyen += (byte)CampementData.Instance.soldats[i].GetTypeCombattant().NiveauCombattant;

        return (byte)(lvlMoyen / CampementData.Instance.soldats.Count);
    }

    private static List<Ennemi> CreateEnnemi(byte lvl)
    {
        List<Ennemi> ennemis = new List<Ennemi>();

        for (int i = 0; i < lvl * 1.5; i++)
            ennemis.Add(new Ennemi(Random.Range(0, 3), lvl));

        return ennemis;
    }

}
