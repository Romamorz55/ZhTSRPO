using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vzriv_EXpiore_Tank : MonoBehaviour
{
    private float forse = 20f;
    public GameObject tank;

    void Start()
    {
        Explode();
        Destroy(gameObject);
    }



    private void Explode()
    {

        for (int i = 0; i < tank.transform.childCount; i++)
        {
            float dist = Vector3.Distance(tank.transform.GetChild(i).transform.position, transform.position);
            Vector3 napravlenie_vzriva = tank.transform.GetChild(i).transform.position - transform.position;
            tank.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
            tank.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().AddRelativeForce((napravlenie_vzriva * forse * (1 / (dist * dist * dist))), ForceMode.Impulse);
        }
    }
}
