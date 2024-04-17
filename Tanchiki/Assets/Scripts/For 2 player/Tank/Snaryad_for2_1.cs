using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaryad_for2_1 : MonoBehaviour
{
    private float schetchik_vremeni = 0;
    public GameObject vzriv_abstrakt;
    public GameObject vzriv_Jeltiy_abstrakt;
    private GameObject _obsh_Perem;
    public GameObject vzriv_Explode_Tank_abstrakt;
    public GameObject Tank_Destroy_abstrack;

    void Start()
    {
        _obsh_Perem = GameObject.Find("___obsch_obect");
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
        if (other.transform.tag == "Enemy_Tank")
        {
            other.transform.tag = "Tank_Destroy"; //чтобы один только раз вызывалась
            GameObject stena_k_real = Instantiate(Tank_Destroy_abstrack) as GameObject;
            stena_k_real.transform.position = other.transform.position;
            stena_k_real.transform.rotation = other.transform.rotation;
            stena_k_real.GetComponent<Tank_Destroy>().otschet_vkluchen = true;
            Destroy(other.gameObject);
            GameObject vzriv_Explode_Steni = Instantiate(vzriv_Explode_Tank_abstrakt) as GameObject;
            vzriv_Explode_Steni.transform.position = transform.position;
            vzriv_Explode_Steni.GetComponent<Vzriv_EXpiore_Tank>().tank = stena_k_real;
            GameObject vzriv = Instantiate(vzriv_abstrakt) as GameObject;
            vzriv.transform.position = transform.position;
            GameObject vzriv_j = Instantiate(vzriv_Jeltiy_abstrakt) as GameObject;
            vzriv_j.transform.position = transform.position;
            _obsh_Perem.GetComponent<Klass_Obshih_Peremennih_2>().Zvuk_Razrusheniya_tanka();
            Destroy(gameObject);
        }



        else
        {
            GameObject vzriv = Instantiate(vzriv_abstrakt) as GameObject;
            vzriv.transform.position = transform.position;
            GameObject vzriv_j = Instantiate(vzriv_Jeltiy_abstrakt) as GameObject;
            vzriv_j.transform.position = transform.position;
            Destroy(gameObject);
        }


    }

}