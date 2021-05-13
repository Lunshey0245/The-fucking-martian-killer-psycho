using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    public int fuelMax;
    public int currentFuel;
    public PlayerFuel fuelBar;

    bool isFlying;


    Vector2 movement;

    Animator _animator;
    Rigidbody2D _rigidBody;

    void Start()
    {
        isFlying = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentFuel = fuelMax;
        fuelBar.SetMaxFuel(fuelMax);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Jump();
        if (Input.GetKeyDown(KeyCode.Space) && currentFuel > 0)
        {
            isFlying = true;
            StartCoroutine(UseFuel());
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

    IEnumerator UseFuel()
    {
        for (float i = currentFuel; i  >= 1; i ++)
        {
            currentFuel -= 2;
            fuelBar.SetFuel(currentFuel);
            yield return new WaitForSeconds(0.01f);

            if (Input.GetKeyUp(KeyCode.Space) || currentFuel < 0)
            {
                isFlying = false;

                break;
            }
        }
    }
}
