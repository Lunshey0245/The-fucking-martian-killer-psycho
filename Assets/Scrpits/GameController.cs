using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public float score;
    public float HighScore;
    [SerializeField]
    Text textScore;

    [SerializeField]
    Text textHighScore;

    public float speed;
    public float currentSpeed = 3;

    public static bool gameStarted;
    public bool gameOver;

    PlayerMovement _playerMovement;
    PlayerAttack _playerAttack;

    [SerializeField]
    bool pressStart;

    [SerializeField]
    CanvasGroup _canvasGameStarted;
    [SerializeField]
    CanvasGroup _canvasGameOver;
    void Start()
    {
        FindAndGet();
        PauseGame();
        CanvasStartedTrue();
        speed = currentSpeed;
        textHighScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
      //  PlayerPrefs.DeleteAll();    
    }

    void Update()
    {
        StartGame();
        if (score > PlayerPrefs.GetFloat("HighScore",0))
        {
            PlayerPrefs.SetFloat("HighScore", (int)score);
            textHighScore.text = ((int)score).ToString();
        }
    }

    public void FindAndGet()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        _playerAttack = FindObjectOfType<PlayerAttack>().GetComponent<PlayerAttack>();
    }
    public void StartGame()
    {
        Score();

        //PressStart();
        if (!gameStarted)
        {
            if (Input.GetMouseButton(0))
            {
                _playerMovement.isUseFuelPerSecond = true;
                _playerAttack.canShot = true;
                speed = 3;
                if (!gameOver)
                {
                    StartCoroutine(UpgrateSpeed());
                }

                CanvasStartedFalse();
                gameStarted = true;
                pressStart = false;

            }
        }
        if (gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (speed > 14)
        {
            StopAllCoroutines();
        }

    }

    public void CanvasStartedTrue()
    {
        _canvasGameStarted.alpha = 1;
        _canvasGameStarted.interactable = true;
        _canvasGameStarted.blocksRaycasts = true;

        _canvasGameOver.alpha = 0;
        _canvasGameOver.interactable = false;
        _canvasGameOver.blocksRaycasts = false;
    }
    public void CanvasStartedFalse()
    {
        _canvasGameStarted.alpha = 0;
        _canvasGameStarted.interactable = false;
        _canvasGameStarted.blocksRaycasts = false;
    }
    public void PressStart()
    {
        if (Input.GetKey("enter") || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            pressStart = true;
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
        speed = 0;
        gameOver = true;

        _canvasGameOver.alpha = 1;
        _canvasGameOver.interactable = true;
        _canvasGameOver.blocksRaycasts = true;


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
    public void Score()
    {
        score += Time.deltaTime * speed;
        textScore.text = ((int)score).ToString();
    }
}
