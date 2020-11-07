using System.Collections;

public class FullyEmpty : State
{
    public override void MouseOne(GunController gunController)
    {
        //play click sound
    }
    
    public override void MouseTwo(GunController gunController)
    {
        //play click sound
    }

    public override IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        int ammoToRemove = oneShotLeft ? 1 : 2;
        gunController.RemoveAmmo(ammoToRemove);
        
        if (oneShotLeft)
        {
            gunController.OnBarrelChanged.Invoke(GunController.Barrel.LEFT, true);
            //reload left barrel anim
            gunController.SetState(new RightBarrelEmpty());
        }
        else
        {
            gunController.OnBarrelChanged.Invoke(GunController.Barrel.BOTH, true);
            //reload both barrels anim
            gunController.SetState(new FullyLoaded());
        }
        yield return null;
    }
}
