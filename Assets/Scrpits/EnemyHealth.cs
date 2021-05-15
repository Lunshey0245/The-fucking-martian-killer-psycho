using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int Health;

    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        }
    }

    IEnumerator SpriteDamage()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = Color.white;
    }
}
