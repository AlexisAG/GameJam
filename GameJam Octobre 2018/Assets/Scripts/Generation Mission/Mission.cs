﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission {

	public enum TypeMission : byte { Defense, Survivant, Recherche };

    private TypeMission p_typeObjectif;
    private byte p_nbObjectif, p_lvlMission;
    private int p_gainMission;
    private string p_nomMission;
    private Vector2Int p_positionMapMission;

    public List<Ennemi> Ennemis = new List<Ennemi>();
    public List<Soldat> Soldats = new List<Soldat>();

    public Mission (TypeMission typeObjectif, byte nbObjectif, byte lvlMission, int gain, string nom, Vector2Int positionMapMission)
    {
        p_typeObjectif = typeObjectif;
        p_nbObjectif = nbObjectif;
        p_gainMission = gain;
        p_nomMission = nom;
        p_lvlMission = lvlMission;
    }

    /* ACCESSEUR */
    public TypeMission GetTypeObjectif ()
    {
        return p_typeObjectif;
    }

    public byte GetNbObjectif ()
    {
        return p_nbObjectif;
    }
    public byte GetLvlMission ()
    {
        return p_lvlMission;
    }

    public int GetGainMission ()
    {
        return p_gainMission;
    }

    public string GetName()
    {
        return p_nomMission;
    }

    public Vector2Int GetPositionOnMap ()
    {
        return p_positionMapMission;
    }

    public void SetNewPositionOnMap (Vector2Int pos)
    {
        if (p_typeObjectif == TypeMission.Defense)
        p_positionMapMission = pos;
    }
}