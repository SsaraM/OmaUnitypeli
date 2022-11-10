using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 3f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // Move background up
        if(gameManager.isGameActive)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        // Destroy background
        if (transform.position.y > 90)
        {
            Destroy(gameObject);
        }

    }
}
