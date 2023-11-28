using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upravlenie_Tankom : MonoBehaviour
{
    public Klass_Obshih_Peremennih ssilka_na_Klass_Obshih;
    public GameObject tank_abstrakt;
    private GameObject tank;
    private Vector3 nachalnaya_poziciya_tanka = new Vector3(0f, 1f, 0f);

    private float napravlenie_Dvijeniya_Tanka;
    private float napravlenie_Povorota_Tanka;
    private float skorost_Dvijeniya_Tanka = 4f;
    private float skorost_Povorota_Tanka = 50f;

    private void Start()
    {
        tank = Instantiate(tank_abstrakt) as GameObject;
        tank.transform.position = nachalnaya_poziciya_tanka;
    }
    void Update()
    {
        Peremeshenie_Tanka();

    }
    private void Peremeshenie_Tanka()
    {
        napravlenie_Dvijeniya_Tanka = 0;
        napravlenie_Povorota_Tanka = 0;
        if (ssilka_na_Klass_Obshih.Povorot_Verh_Global)
        {
            napravlenie_Dvijeniya_Tanka = 1;
        }

        if (ssilka_na_Klass_Obshih.Povorot_Niz_Global)
        {
            napravlenie_Dvijeniya_Tanka = -1;
        }

        if (ssilka_na_Klass_Obshih.Povorot_Pravo_Global)
        {
            if (napravlenie_Dvijeniya_Tanka == -1)
            {
                napravlenie_Povorota_Tanka = -1;
            }
            else
                napravlenie_Povorota_Tanka = 1;
        }
        if (ssilka_na_Klass_Obshih.Povorot_Levo_Global)
        {
            if (napravlenie_Dvijeniya_Tanka == -1)
            {
                napravlenie_Povorota_Tanka = 1;
            }
            else
                napravlenie_Povorota_Tanka = -1;


        }

        tank.transform.Translate(0, 0, napravlenie_Dvijeniya_Tanka * skorost_Dvijeniya_Tanka * Time.deltaTime, Space.Self);
        tank.transform.Rotate(0, napravlenie_Povorota_Tanka * skorost_Povorota_Tanka * Time.deltaTime, 0, Space.Self);

    }
}
