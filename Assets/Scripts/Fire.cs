using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletTimer;
    
    void Start()
    {
       
    }

    
    void Update()
    {
        
            BulletTimer += Time.deltaTime;
            if (BulletTimer > 1/Rush.Instance.FirePower)
            {
                BulletTimer = 0;
                Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            }
       
    }
}
