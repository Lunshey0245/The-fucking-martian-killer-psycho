using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public bool isReadyToAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToAttack)
        {
            isReadyToAttack = false;
            StartCoroutine(WaitAndShoot());
        }
    }

    IEnumerator WaitAndShoot()
    {
        yield return new WaitForSeconds(Random.Range(3, 8));
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        isReadyToAttack = true;
    }
}
