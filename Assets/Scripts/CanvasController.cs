using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject ChildObject1, ChildObject2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Canvas.activeSelf)
        {
            GetComponent<MeshRenderer>().enabled = false;
            ChildObject1.SetActive(true);
            ChildObject2.SetActive(true);
        }
    }
}
