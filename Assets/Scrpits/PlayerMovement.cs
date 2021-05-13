using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector2 movement;

    Rigidbody2D _rigidBody;


    [SerializeField]
    float jumpForce;

    bool isFlying;

    Animator _animator;

    void Start()
    {
        isFlying = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Jump();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFlying = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlying = false;
        }

    }
    private void FixedUpdate()
    {
        //FreeMovement();
        JumpForce();

    }
    public void FreeMovement()
    {
        _rigidBody.MovePosition(_rigidBody.position + movement * speed * Time.fixedDeltaTime);
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _rigidBody.velocity = Vector2.up * jumpForce;
        }
    }


    public void JumpForce()
    {
        switch (isFlying)
        {
            case true:
                _rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                break;
            case false:
                _rigidBody.AddForce(new Vector2(0f, 0f), ForceMode2D.Force);
                break;
        }
    }
}
