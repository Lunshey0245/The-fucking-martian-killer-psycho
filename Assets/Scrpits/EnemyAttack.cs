using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public int minDelay;
    public int maxDelay;

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
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        isReadyToAttack = true;
    }
}
