using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private Rigidbody rigidbody;

    private Transform transform;

    public bool onGround;

    RaycastHit hit;

    public PlayerJumpingState(PlayerController player) : base(player)
    {
        rigidbody = player.GetComponent<Rigidbody>();
        transform = player.GetComponent<Transform>();
    }

    public override void FixedTick(float fixedDeltaTime)
    {
        base.FixedTick(fixedDeltaTime);

        onGround = OnGround();

       if (onGround)
         Jump();

        FasterFall();
    }

    private bool OnGround()
    {
        if (Physics.BoxCast(transform.GetComponent<Collider>().bounds.center,
                    transform.localScale, -Vector3.up, out hit, transform.rotation, 20.0f))
            return hit.distance <= 0.28f ? true : false;

        return false;
    }

    private void Jump()
    {
        rigidbody.velocity += Vector3.up * playerController.JumpMultiplier * Time.deltaTime;
    }

    private void FasterFall()
    {
        if (!onGround && rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (playerController.FallMultiplier - 1) * Time.deltaTime;
            Debug.Log(rigidbody.velocity);
        }
    }
}
