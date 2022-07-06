using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static GunController Instance;
    [SerializeField] float XSpeed;
    float Vec=8;
    public float ZSpeed;
    [SerializeField] float MaxX;
    public Vector3 MovementVector;
    private bool Go;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
            MovementVector.x = Input.GetAxis("Mouse X")*XSpeed;
        }
        else
        {
            MovementVector.x = 0;
        }
        transform.Translate(Vec * Time.deltaTime * MovementVector);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -MaxX, MaxX), transform.position.y, transform.position.z);

    }
}
