using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        // Game over
        if (transform.position.y > 48)
        {
            gameManager.GameOver();
        }
    }
}
