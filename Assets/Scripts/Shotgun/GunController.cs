using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GunController : StateMachine
{
    public enum Barrel
    {
        LEFT,
        RIGHT,
        BOTH
    }
    
    public PlayerStats playerStats;
    public S_GunStats gunStats;

    [SerializeField]
    private Transform shootPoint;
    
    #region GunStats

    private int damage;
    private float range;
    private float angle;
    private int bulletsInShot;
    
    #endregion
    
    public KeyCode ReloadKey = KeyCode.R;

    [System.NonSerialized]
    public UnityEvent<int> OnAmmoChanged;
    [System.NonSerialized]
    public UnityEvent<Barrel, bool> OnBarrelChanged;
    private void Awake()
    {
        OnAmmoChanged = new UnityEvent<int>();
        OnBarrelChanged = new UnityEvent<Barrel, bool>();
        
        SetState(new FullyLoaded());
        damage = gunStats.damage;
        range = gunStats.range;
        angle = gunStats.coneAngle;
        bulletsInShot = gunStats.bullets;
    }
    
    List<Vector3> debugpos = new List<Vector3>();

    public void Shoot()
    {
        Debug.Log("Boom");
        float radAngle = Mathf.Deg2Rad * (angle/2);
        //radius for cone end
        float rEnd = Mathf.Tan(radAngle) * range;

        float r = rEnd;
        Vector3 currentposition = shootPoint.position;

        for (int i = 0; i < bulletsInShot; i++)
        {
            float t = (float)i / bulletsInShot;
            r = Mathf.Lerp(rEnd, 0, t);
            Debug.Log(t);
            Vector2 divergence = Random.onUnitSphere;
            divergence *= r;
            Vector3 localEndPoint = new Vector3(divergence.x, divergence.y, range);
            Vector3 endPoint = shootPoint.localToWorldMatrix * localEndPoint;

            if (Physics.Raycast(currentposition, endPoint, out RaycastHit hit, range))
            {
                debugpos.Add(hit.point);
            }
            else
            {
                Debug.Log("nothing hit");
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootOne();
        }
    
        if (Input.GetMouseButtonDown(1))
        {
            ShootTwo();
        }
    
        if (Input.GetKeyDown(ReloadKey))
        {
            Reload();
        }
    }

    public void ShootOne()
    {
        currentState.MouseOne(this);
    }
    
    public void ShootTwo()
    {
        currentState.MouseTwo(this);
    }

    public void Reload()
    {
        if (playerStats.ammo > 0)
        {
            StartCoroutine(currentState.Reload(this, playerStats.ammo < 2));
        }
    }

    public void RemoveAmmo(int ammoToRemove)
    {
        playerStats.ammo -= ammoToRemove;
        OnAmmoChanged.Invoke(playerStats.ammo);
    }
    
    #if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Vector3 endPoint = shootPoint.forward * gunStats.range;
        Vector3 startPos = Quaternion.AngleAxis(-gunStats.coneAngle / 2, Vector3.up) * endPoint;
        Handles.DrawSolidArc(shootPoint.position, Vector3.up, startPos, gunStats.coneAngle, gunStats.range);

        Handles.color = Color.magenta;
        foreach (var vector3 in debugpos)
        {
            Gizmos.DrawSphere(vector3, 0.1f);
        }
    }

    #endif
}
