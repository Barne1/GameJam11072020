using System.Collections;

public class RightBarrelEmpty : State
{
    public override void MouseOne(GunController gunController)
    {
        gunController.Shoot();
        //play gun animation
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.LEFT, false);
        gunController.SetState(new FullyEmpty());
    }
    
    public override void MouseTwo(GunController gunController)
    {
        //play click sound
    }

    public override IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.RIGHT, true);
        gunController.RemoveAmmo(1);
        //reload left barrel anim
        gunController.SetState(new FullyLoaded());
        yield return null;
    }
}
