using UnityEngine;

public class PillarRotator : MonoBehaviour {

    private PillarRotatorBaseState currentState;

    private void Start()
    {
        SetState(new PillarRotatorRotatingState(this));
    }

    private void Update()
    {
        currentState.Tick(Time.deltaTime);
    }

    public void SetState(PillarRotatorBaseState newState)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = newState;

        if (currentState != null)
            currentState.OnStateEnter();
    }

}