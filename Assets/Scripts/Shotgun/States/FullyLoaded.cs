using System.Collections;

public class FullyLoaded : State
{
    public override IEnumerator MouseOne(GunController gunController)
    {
        gunController.Shoot();
        yield return null;
        //play gun animation
        gunController.SetState(new LeftBarrelEmpty());
    }
    
    public override IEnumerator MouseTwo(GunController gunController)
    {
        gunController.Shoot();
        yield return null;
        //play gun animation
        gunController.SetState(new LeftBarrelEmpty());
    }
    
    //no reload
}
