using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [System.NonSerialized]
    public int hp;
    [System.NonSerialized]
    public int ammo;

    public ScriptablePlayerStats stats;

    private void Awake()
    {
        hp = stats.hp;
        ammo = stats.ammo;
    }
}
