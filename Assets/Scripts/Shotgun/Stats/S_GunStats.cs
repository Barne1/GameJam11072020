using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GunStats", fileName = "NewGunStats")]
public class S_GunStats : ScriptableObject
{
    public int damage;
    
    [Range(0f, 100f)]
    public float range;
    public float coneAngle;
    public int bullets;
}
