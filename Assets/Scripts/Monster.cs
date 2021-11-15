using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [HideInInspector] public float speed;
    private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = 7f;

    }

    // Update is called once per frame
    void Update()
    {
        // addForce is not the only way to do this, get to know velocity property:
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }
}

