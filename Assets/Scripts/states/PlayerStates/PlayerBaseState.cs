using UnityEngine;


public abstract class PlayerBaseState {

    protected PlayerController playerController;

    // It is to be called in the Update or FixedUpdate function
    public virtual void Tick(float deltaTime)           { }

    public virtual void FixedTick(float fixedDeltaTime) { }
    public virtual void OnStateEnter()                  { }
    public virtual void OnStateExit()                   { }

    public PlayerBaseState(PlayerController player)
    {
        this.playerController = player;
    }

}
