using System.Collections;

public class FullyLoaded : State
{
    public override void MouseOne(GunController gunController)
    {
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.LEFT, false);
        gunController.Shoot();
        //play gun animation
        gunController.SetState(new LeftBarrelEmpty());
    }
    
    public override void MouseTwo(GunController gunController)
    {
        gunController.OnBarrelChanged.Invoke(GunController.Barrel.RIGHT, false);
        gunController.Shoot();
        //play gun animation
        gunController.SetState(new RightBarrelEmpty());
    }
    //no reload
}
