using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaryad : MonoBehaviour
{
    private float schetchik_vremeni = 0;
    public GameObject vzriv_abstrakt;
    public GameObject vzriv_Jeltiy_abstrakt;

    void Start()
    {
    }


    void Update()
    {
        schetchik_vremeni += Time.deltaTime;
        if (schetchik_vremeni >= 10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        GameObject vzriv = Instantiate(vzriv_abstrakt) as GameObject;
        vzriv.transform.position = transform.position;
        GameObject vzriv_j = Instantiate(vzriv_Jeltiy_abstrakt) as GameObject;
        vzriv_j.transform.position = transform.position;
        Destroy(gameObject);
    }

}