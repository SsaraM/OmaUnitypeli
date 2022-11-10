using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] background;

    private Vector3 spawnPos = new Vector3(0, -50, 3);
    private float startDelay = 1;
    private float repeatRate = 20;
    private GameManager gameManager;

    // Start is called before the first frame
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnBackground", startDelay, repeatRate);
    }

    void SpawnBackground()
    {
        if (gameManager.isGameActive)
        {
            int backgroundIndex = Random.Range(0, 3);

            Instantiate(background[backgroundIndex], spawnPos, background[backgroundIndex].transform.rotation);
        }
    }
}
