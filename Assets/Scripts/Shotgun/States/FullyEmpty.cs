using System.Collections;

public class FullyEmpty : State
{
    public override IEnumerator MouseOne(GunController gunController)
    {
        //play click sound
        yield return null;
    }
    
    public override IEnumerator MouseTwo(GunController gunController)
    {
        //play click sound
        yield return null;
    }

    public override IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        int ammoToRemove = oneShotLeft ? 1 : 2;
        gunController.RemoveAmmo(ammoToRemove);
        
        if (oneShotLeft)
        {
            //reload left barrel anim
        }
        else
        {
            //reload both barrels anim
        }
        gunController.SetState(new FullyLoaded());
        yield return null;
    }
}
