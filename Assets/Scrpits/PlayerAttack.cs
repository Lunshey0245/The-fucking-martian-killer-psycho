using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    GameObject plasmaBullet;

    [SerializeField]
    Transform posSpawnBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            Instantiate(plasmaBullet, posSpawnBullet.position, Quaternion.identity);
        }        
    }
}
