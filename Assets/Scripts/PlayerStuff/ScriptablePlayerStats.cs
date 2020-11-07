using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats", fileName = "NewPlayerStats")]
public class ScriptablePlayerStats : ScriptableObject
{
    public int hp = 10;
    public int ammo = 20;
}
