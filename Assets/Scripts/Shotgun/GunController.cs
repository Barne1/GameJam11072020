using System;
using UnityEngine;

public class GunController : StateMachine
{
    public PlayerStats playerStats;
    public KeyCode ReloadKey = KeyCode.R;
    private void Awake()
    {
        SetState(new FullyLoaded());
    }

    public void Shoot()
    {
        Debug.Log("Boom");
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
        StartCoroutine(currentState.MouseOne(this));
    }
    
    public void ShootTwo()
    {
        StartCoroutine(currentState.MouseTwo(this));
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
    }
}
