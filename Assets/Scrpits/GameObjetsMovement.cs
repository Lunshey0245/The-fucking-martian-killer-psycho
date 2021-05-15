using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjetsMovement : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    GameController _gameController;

    float speed;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    void Update()
    {
        _rigidBody.velocity = transform.right * -_gameController.speed;
    }
}
