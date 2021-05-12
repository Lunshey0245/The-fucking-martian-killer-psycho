using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    GameController _gameController;

    bool isHelicoptero;

    float speed;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    void Update()
    {
        if (isHelicoptero)
        {
            _rigidBody.velocity = transform.right * -speed;
        }
        _rigidBody.velocity = transform.right * -_gameController.speed;
    }
}
