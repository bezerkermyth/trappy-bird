using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject2D : MonoBehaviour
{
    public float MinGroundNormalY = .65f;
    public float GravityModifier = 1f;

    protected Vector2 TargetVelocity;
    protected bool Grounded;
    protected Vector2 GroundNormal;
    protected Rigidbody2D Rigidbody;
    protected Vector2 Velocity;
    protected ContactFilter2D ContactFilter;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D>(16);

    protected const float MIN_MOVE_DISTANCE = 0.001f;
    protected const float SHELL_RADIUS = 0.005f;

    void OnEnable()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ContactFilter.useTriggers = false;
        ContactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        ContactFilter.useLayerMask = true;
    }

    void Update()
    {
        TargetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity() { }

    void FixedUpdate()
    {
        Velocity += GravityModifier * Physics2D.gravity * Time.deltaTime;
        Velocity.x = TargetVelocity.x;

        Grounded = false;

        Vector2 deltaPosition = Velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(GroundNormal.y, -GroundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > MIN_MOVE_DISTANCE)
        {
            int count = Rigidbody.Cast(move, ContactFilter, HitBuffer, distance + SHELL_RADIUS);
            HitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                HitBufferList.Add(HitBuffer[i]);
            }

            for (int i = 0; i < HitBufferList.Count; i++)
            {
                Vector2 currentNormal = HitBufferList[i].normal;
                if (currentNormal.y > MinGroundNormalY)
                {
                    Grounded = true;
                    if (yMovement)
                    {
                        GroundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(Velocity, currentNormal);
                if (projection < 0)
                {
                    Velocity = Velocity - projection * currentNormal;
                }

                float modifiedDistance = HitBufferList[i].distance - SHELL_RADIUS;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }
        Rigidbody.position = Rigidbody.position + move.normalized * distance;
    }
}
