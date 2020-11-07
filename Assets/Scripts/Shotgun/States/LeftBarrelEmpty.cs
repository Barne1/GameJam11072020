using System.Collections;

public class LeftBarrelEmpty : State
{
    public override void MouseOne(GunController gunController)
    {
        //play click sound
    }

    public override void MouseTwo(GunController gunController)
    {
        gunController.Shoot();
        //play gun animation
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.RIGHT, false);
        gunController.SetState(new FullyEmpty());
    }

    public override IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.LEFT, true);
        gunController.RemoveAmmo(1);
        //reload left barrel anim
        gunController.SetState(new FullyLoaded());
        yield return null;
    }
}
