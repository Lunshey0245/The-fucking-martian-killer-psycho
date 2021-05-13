using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        speed = 0;
    }
    public void PauseGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 3;
        }
    }

    public void GameOver()
    {

    }
}
