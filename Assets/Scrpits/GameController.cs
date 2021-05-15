using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float speed;

    public static bool gameStarted;
    public bool gameOver;

    PlayerMovement _playerMovement;
    void Start()
    {
        PauseGame();
        _playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    void Update()
    {
        StartGame();
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerMovement.isUseFuelPerSecond = true;
                speed = 3;
                StartCoroutine(UpgrateSpeed());
                gameStarted = true;

            }
        }

    }
    public void PauseGame()
    {
        speed = 0;
        gameStarted = false;
        gameOver = false;
    }

    public void GameOver()
    {
       
    }

    IEnumerator UpgrateSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            speed += 0.1f;
            if (gameOver)
            {
                break;
            }
        }
    }

    public static bool GetGameState()
    {
        return gameStarted;
    }

}
