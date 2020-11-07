using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image shellLeft, shellRight;
    [SerializeField] private Text ammoCounter;

    [SerializeField] private GunController mainGun;

    private void Start()
    {
        UpdateAmmoCounter(mainGun.playerStats.ammo);
        mainGun.OnAmmoChanged.AddListener(UpdateAmmoCounter);
        mainGun.OnBarrelChanged.AddListener(UpdateShells);
    }

    private void UpdateAmmoCounter(int ammo)
    {
        ammoCounter.text = ammo.ToString();
    }

    private void UpdateShells(GunController.Barrel barrel, bool loaded)
    {
        switch (barrel)
        {
            default: break;
            case GunController.Barrel.BOTH:
                ActivateShell(shellLeft, loaded);
                ActivateShell(shellRight, loaded);
                break;
            case GunController.Barrel.LEFT:
                ActivateShell(shellLeft, loaded);
                break;
            case GunController.Barrel.RIGHT:
                ActivateShell(shellRight, loaded);
                break;
        }
    }

    private void ActivateShell(Image shell, bool loaded)
    {
        shell.gameObject.SetActive(loaded);
    }
}
