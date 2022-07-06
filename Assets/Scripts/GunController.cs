using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    [SerializeField] float XSpeed;
    [SerializeField] float ZSpeed;
    [SerializeField] float MaxX;
    private Vector3 MovementVector;
    private bool Go;
    void Start()
    {
        MovementVector = new Vector3(0, 0, ZSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Go)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Go = true;

            }
            return;
        }
        Movement();
    }
    private void Movement()
    {
        if (Input.GetMouseButton(0))
        {
            MovementVector.x = Input.GetAxis("Mouse X");
        }
        else
        {
            MovementVector.x = 0;
        }
        transform.Translate(XSpeed * Time.deltaTime * MovementVector);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -MaxX, MaxX), transform.position.y, transform.position.z);

    }
}
