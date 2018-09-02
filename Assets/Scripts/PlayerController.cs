using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerBaseState currentState;

    [SerializeField]
    private float fallMultiplier = 800f;
    [SerializeField]
    private float jumpMultiplier = 600f;

    public float FallMultiplier
    {
        get { return fallMultiplier; }
        set { fallMultiplier = value; }
    }

    public float JumpMultiplier
    {
        get { return jumpMultiplier; }
        set { jumpMultiplier = value; }
    }

    private void Start()
    {
        SetState(new PlayerJumpingState(this));
    }

    private void FixedUpdate()
    {
        currentState.FixedTick(Time.fixedDeltaTime);
    }

    public void SetState(PlayerBaseState newState)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = newState;

        if (currentState != null)
            currentState.OnStateEnter();
    }
}
