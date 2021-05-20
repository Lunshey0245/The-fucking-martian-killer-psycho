using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int Health;
    [SerializeField]
    GameObject fuelReward;
    [SerializeField]
    GameObject GOToDie;
    SpriteRenderer _spriteRenderer;

    [SerializeField]
    GameObject[]partsObstacle;

    GameController _gameController;

    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        StartCoroutine(SpriteDamage());
        if (Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(GOToDie, transform.position, Quaternion.identity);
            _gameController.score += 5;

            foreach (var part in partsObstacle)
            {
                Instantiate(part, transform.position, Quaternion.identity);
            }
            if (Random.Range(0,2) == 1)
            {
                //Instantiate(fuelReward, this.transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator SpriteDamage()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }
}
