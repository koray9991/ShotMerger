using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Barrel")
        {
            
                Destroy(gameObject);
            
        }
    }
}
