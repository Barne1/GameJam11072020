using System;
using UnityEngine;

public class GunController : StateMachine
{
    public KeyCode ReloadKey = KeyCode.R;
    private void Start()
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
        StartCoroutine(currentState.Reload(this));
    }
}
