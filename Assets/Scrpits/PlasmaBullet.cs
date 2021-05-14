using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    [SerializeField]
    float speedBullet;

    [SerializeField]
    int bulletDamage;

    Rigidbody2D _rigidBody;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody.velocity = new Vector2(speedBullet, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }


}
