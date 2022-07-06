using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barrel : MonoBehaviour
{
    public int Health;
    public Text HealthText;
    void Start()
    {
        HealthText.text = Health.ToString();
    }

   
    void Update()
    {
        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Health -= 1;
            HealthText.text = Health.ToString();
        }
    }
}
