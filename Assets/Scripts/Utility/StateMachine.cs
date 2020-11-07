using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }

    public void SetState(State newState)
    {
        currentState = newState;
    }
}
