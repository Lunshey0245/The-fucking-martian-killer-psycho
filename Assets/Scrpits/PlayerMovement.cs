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
    public int fuelPerSecond;
    public PlayerFuel fuelBar;

    bool isFlying;
    public bool isUseFuelPerSecond;

    [SerializeField]
    Animator _animatorChildren;

    Rigidbody2D _rigidBody;

    [SerializeField]
    bool isDead = false;
    void Start()
    {
        isFlying = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        
        currentFuel = fuelMax;
        fuelBar.SetMaxFuel(fuelMax);
        isUseFuelPerSecond = false;
    }


    void Update()
    {
        if (isDead)
        {
            //Cuando Muere
        }
        if (Input.GetKeyDown(KeyCode.Space) && currentFuel > 0)
        {
            isFlying = true;
            _animatorChildren.SetBool("Isflying", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFlying = false;
            _animatorChildren.SetBool("Isflying", false);
        }

        if (isFlying)
        {
            UseFuel(1);
        }
        if (isUseFuelPerSecond)
        {
            isUseFuelPerSecond = false;
            StartCoroutine(UseFuelAlways());
        }
    }
    private void FixedUpdate()
    {

        JumpForce();
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

    public void UseFuel(int usedFuel)
    {
        currentFuel -= usedFuel;
        fuelBar.SetFuel(currentFuel);
        if (currentFuel <= 0)
        {
            isFlying = false;
            isDead = true;
        }   
    }

    IEnumerator UseFuelAlways()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            currentFuel -= fuelPerSecond;
            fuelBar.SetFuel(currentFuel);
            if (currentFuel <= 0)
            {
                isDead = true;
                currentFuel = 0;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fuel"))
        {
            currentFuel += 200;
            if (currentFuel > fuelMax)
            {
                currentFuel = fuelMax;
            }
            fuelBar.SetFuel(currentFuel);
            Destroy(collision.gameObject);
        }
    }
}
