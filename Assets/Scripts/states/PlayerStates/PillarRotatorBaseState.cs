using UnityEngine;

public abstract class PillarRotatorBaseState
{
    protected PillarRotator pillarRotator;

    public virtual void Tick(float deltaTime)           { }

    public virtual void FixedTick(float fixedDeltaTIme) { }
    public virtual void OnStateEnter()                  { }
    public virtual void OnStateExit()                   { }

    public PillarRotatorBaseState(PillarRotator pillar)
    {
        this.pillarRotator = pillar;
    }

}
