using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Destroy : MonoBehaviour
{
    public bool otschet_vkluchen = false;
    float schetchik_vremeni = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (otschet_vkluchen)
        {
            schetchik_vremeni += Time.deltaTime;
            if (schetchik_vremeni >= 10f)
            {
                Destroy(gameObject);
            }
        }
    }
}
