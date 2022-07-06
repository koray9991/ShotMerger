using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : MonoBehaviour
{
    public static Rush Instance;
    public List<GameObject> cubes = new List<GameObject>();
    public float FirePower;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        FirePower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (FirePower < 1) FirePower = 1;
    }

    public void StackCube(GameObject other,int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = new Vector3(other.transform.localPosition.x, cubes[index].transform.localPosition.y, cubes[index].transform.localPosition.z);
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cubes.Add(other);
    }
}
