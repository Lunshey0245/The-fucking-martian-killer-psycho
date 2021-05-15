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

    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            // YA SE QUE SE HACE CON UN FOR pero ya me las estoy picandoy queria ver como quedaba
            Instantiate(partsObstacle[0], transform.position, Quaternion.identity);
            Instantiate(partsObstacle[1], transform.position, Quaternion.identity);
            Instantiate(partsObstacle[2], transform.position, Quaternion.identity);
            Instantiate(partsObstacle[3], transform.position, Quaternion.identity);

            if (Random.Range(0,2) == 1)
            {
                Instantiate(fuelReward, this.transform.position, Quaternion.identity);
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
