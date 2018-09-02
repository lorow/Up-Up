using UnityEngine;

public class PillarRotatorRotatingState : PillarRotatorBaseState
{
    private Transform transform;

    Touch touch;
    float rotationSpeed = 0.20f;

    public PillarRotatorRotatingState(PillarRotator pillar) : base(pillar)
    {
        transform = pillar.GetComponent<Transform>();
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
        if (Input.touchCount == 1)
        { // just so we have only one finger
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
                transform.Rotate(Vector3.up, touch.deltaPosition.x * rotationSpeed);

        }
    }
}
