using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10f;
    private int direction = 1;
    private bool isNegative = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= 65 && !isNegative) 
        {
            direction *= -1;
            isNegative = true;
        }
        if (transform.position.x <= -65 && isNegative)
        {
            direction *= -1;
            isNegative = false;
        }

        rb.velocity = new Vector3(speed * direction, 0, 0);
    }
}
