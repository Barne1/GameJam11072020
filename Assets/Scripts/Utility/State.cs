using System.Collections;

public abstract class State
{
    public virtual void MouseOne(GunController gunController)
    {
    }

    public virtual void MouseTwo(GunController gunController)
    {
    }

    public virtual IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        yield return null;
    }
}
