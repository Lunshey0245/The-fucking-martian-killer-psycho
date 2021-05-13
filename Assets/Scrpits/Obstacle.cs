using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float speed;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);    
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
