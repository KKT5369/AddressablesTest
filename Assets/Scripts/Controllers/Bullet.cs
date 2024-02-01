using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector3 mousePosition;
    private float speed = 5f;
    
    private void Awake()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,
                                        - Camera.main.transform.position.z));

        var dir = mousePosition - transform.position;
        
        rb.velocity = dir * speed;
        
        Destroy(gameObject, 2f);
    }
}
