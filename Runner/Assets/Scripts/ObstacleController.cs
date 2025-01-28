using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private PlayerSpawnerController playerSpawner;
    private GameObject playerSpawnerGO;
    void Start()
    {
        playerSpawnerGO = GameObject.FindGameObjectWithTag("PlayerSpawner");
        playerSpawner = playerSpawnerGO.GetComponent<PlayerSpawnerController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Kill the player.
            playerSpawner.PlayerGotKilled(other.gameObject);
        }
    }
}
