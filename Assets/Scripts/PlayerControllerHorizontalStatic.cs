using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerHorizontalStatic : PhysicsObject
{
    
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public bool horizontalControls = false;
    public bool flappyJump = true;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    private GameObject bgCamera;

    private float bgSpeed;


    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();


        CameraController cmct = Camera.main.GetComponent<CameraController>();
        //bgSpeed = cmct.speed;

    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (horizontalControls)
        {     
            //move.x = Input.GetAxis("Horizontal") * maxSpeed + bgSpeed;
            move.x = Input.GetAxis("Horizontal") * maxSpeed;
        }
        


        if (Input.GetButtonDown("Jump") && grounded || Input.GetButtonDown("Jump") && flappyJump)

        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }
        
   
      

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        if (horizontalControls)
        targetVelocity = move ;

    }
}
