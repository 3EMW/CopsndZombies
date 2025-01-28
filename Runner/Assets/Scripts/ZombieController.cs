using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public GameObject playerSpawnerGO;
    public ZombieSpawnerController zombieSpawner;
    private bool isZombieAlive;
    void Start()
    {
        isZombieAlive = true;
    }

    void FixedUpdate()
    {
        if (zombieSpawner.isZombieAttacking == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerSpawnerGO.transform.position, Time.fixedDeltaTime * 1.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isZombieAlive == true)
        {
            isZombieAlive = false;
            zombieSpawner.ZombieAttackThisPlayer(collision.gameObject, this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            zombieSpawner.ZombieGotShoot(this.gameObject);
            //kill zombies
        }
    }
}
