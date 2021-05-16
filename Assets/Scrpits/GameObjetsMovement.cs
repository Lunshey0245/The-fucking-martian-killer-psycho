using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameObjetsMovement : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    GameController _gameController;

    [SerializeField]
    float speedUpgrate;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    void Update()
    {
        _rigidBody.velocity = transform.right * -(_gameController.speed + speedUpgrate);
    }
}
