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

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
       rb.velocity = new Vector2(joyStick.Horizontal * moveSpeed, joyStick.Vertical * moveSpeed); 
    }
}
