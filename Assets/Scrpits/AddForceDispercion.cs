using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AddForceDispercion : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    float dirX;
    float dirY;
    void Start()
    {
        dirX = Random.Range(-9, -1);
        dirY = Random.Range(6, 9);
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
        Destroy(gameObject, 4f);
    }

    public void DestruirAlTerminarAnimacion()
    {
        Destroy(gameObject);
    }
}
