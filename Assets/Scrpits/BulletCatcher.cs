using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCatcher : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
