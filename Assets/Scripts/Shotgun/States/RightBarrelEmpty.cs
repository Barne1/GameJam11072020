﻿using System.Collections;

public class RightBarrelEmpty : State
{
    public override IEnumerator MouseOne(GunController gunController)
    {
        gunController.Shoot();
        //play gun animation
        yield return null;
        gunController.SetState(new FullyEmpty());
    }
    
    public override IEnumerator MouseTwo(GunController gunController)
    {
        //play click sound
        yield return null;
    }

    public override IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        gunController.RemoveAmmo(1);
        //reload left barrel anim
        gunController.SetState(new FullyLoaded());
        yield return null;
    }
}
