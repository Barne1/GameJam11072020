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

    public override IEnumerator Reload(GunController gunController)
    {
        //reload both barrels anim
        gunController.SetState(new FullyLoaded());
        yield return null;
    }
}
