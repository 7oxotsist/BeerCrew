using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private FixedJoystick joyStick;

    [SerializeField]
    private float moveSpeed;
    private bool facingRight;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float moveInputHorizontal = joyStick.Horizontal;
        float moveInputVertical = joyStick.Vertical;

       rb.velocity = new Vector2(moveInputHorizontal * moveSpeed, moveInputVertical * moveSpeed);

       if(moveInputHorizontal>0 && facingRight)
       {
           Flip();
       }
       else if(moveInputHorizontal<0 && !facingRight)
       {
           Flip();
       }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
