using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5;
    float startX;
    float addX;

    // Start at your current axis
    void Start()
    {
        startX = transform.position.x;
    }

    // Back and forth motion
    void Update()
    {
        addX = Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(startX + addX, transform.position.y, transform.position.z);
    }
}
