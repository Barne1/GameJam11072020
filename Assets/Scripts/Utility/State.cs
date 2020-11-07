using System.Collections;

public abstract class State
{
    public virtual IEnumerator MouseOne(GunController gunController)
    {
        yield return null;
    }

    public virtual IEnumerator MouseTwo(GunController gunController)
    {
        yield return null;
    }

    public virtual IEnumerator Reload(GunController gunController, bool oneShotLeft)
    {
        yield return null;
    }
}
