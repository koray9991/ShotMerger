using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            if (!Rush.Instance.cubes.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                
                for (int i = 0; i < other.transform.childCount; i++)
                {
                    other.transform.GetChild(i).GetComponent<Fire>().enabled = true;
                }
                
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                Rush.Instance.StackCube(other.gameObject, Rush.Instance.cubes.Count - 1);


                if (other.name == "+1")
                {
                    Rush.Instance.FirePower += 1;
                }
                if (other.name == "+2")
                {
                    Rush.Instance.FirePower += 2;
                }
                if (other.name == "+3")
                {
                    Rush.Instance.FirePower += 3;
                }
                if (other.name == "X2")
                {
                    Rush.Instance.FirePower *= 2;
                }
                if (other.name == "X3")
                {
                    Rush.Instance.FirePower *= 3;
                }
                
            }
        }
        if (other.tag == "Trap" || other.tag == "Barrel")
        {
            if (gameObject != Rush.Instance.cubes[0])
            {
                GetComponent<Collision>().enabled = false;
                Rush.Instance.cubes.Remove(gameObject);
                transform.parent = null;
                transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<Fire>().enabled = false;
                }
                
                if (transform.name == "+1")
                {
                    Rush.Instance.FirePower -= 1;
                }
                if (transform.name == "+2")
                {
                    Rush.Instance.FirePower -= 2;
                }
                if (transform.name == "+3")
                {
                    Rush.Instance.FirePower -= 3;
                }
                if (transform.name == "X2")
                {
                    Rush.Instance.FirePower /= 2;
                }
                if (transform.name == "X3")
                {
                    Rush.Instance.FirePower /= 3;
                }
                
            }
            else
            {
                if(other.tag == "Trap")
                {
                    Rush.Instance.FirePower = 1;
                    for (int i = 1; i < transform.parent.childCount; i++)
                    {
                        transform.parent.GetChild(i).parent = null;
                        Rush.Instance.cubes.Remove(Rush.Instance.cubes[i]);

                    }
                    transform.parent.GetComponent<GunController>().enabled = false;
                    GetComponent<Rigidbody>().isKinematic = false;

                    GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Random.Range(-200, -300)));
                    StartCoroutine(EditRigidbody());
                }
               
            }
           
            
        }
    }
    private void Update()
    {
        if (transform.parent == null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Fire>().enabled = false;
            }
        }
    }
    IEnumerator EditRigidbody()
    {

        yield return new WaitForSeconds(0.5f);
        transform.parent.GetComponent<GunController>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        
    }
}
