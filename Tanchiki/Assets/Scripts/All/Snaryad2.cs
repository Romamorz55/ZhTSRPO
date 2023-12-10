using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snaryad2 : MonoBehaviour
{
    //public Player_Manager ssilka_na_player_manager;
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
        
        if (other.transform.tag == "Tank_Player")
        {
            Player_Manager.Damage(1);

            GameObject vzriv = Instantiate(vzriv_abstrakt) as GameObject;
            vzriv.transform.position = transform.position;
            GameObject vzriv_j = Instantiate(vzriv_Jeltiy_abstrakt) as GameObject;
            vzriv_j.transform.position = transform.position;
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