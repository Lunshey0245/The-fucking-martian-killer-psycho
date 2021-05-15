using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int Health;
    [SerializeField]
    GameObject fuelReward;

    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
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
