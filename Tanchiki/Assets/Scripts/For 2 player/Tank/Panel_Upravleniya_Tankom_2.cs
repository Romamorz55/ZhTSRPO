using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Upravleniya_Tankom_2 : MonoBehaviour
{
    public Klass_Obshih_Peremennih_1 klass_Obshih_Peremennih;


    private void Update()
    {
        Otslejivanie_Najatiya_Strelok();
    }

    private void Otslejivanie_Najatiya_Strelok()
    {
        if (Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S))
        {
            klass_Obshih_Peremennih.Povorot_Verh_Global_1 = true;
        }
        else
        {
            klass_Obshih_Peremennih.Povorot_Verh_Global_1 = false;
        }
        if (Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.W))
        {
            klass_Obshih_Peremennih.Povorot_Niz_Global_1 = true;
        }
        else
        {
            klass_Obshih_Peremennih.Povorot_Niz_Global_1 = false;
        }
        if (Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D))
        {
            klass_Obshih_Peremennih.Povorot_Levo_Global_1 = true;
        }
        else
        {
            klass_Obshih_Peremennih.Povorot_Levo_Global_1 = false;
        }
        if (Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.A))
        {
            klass_Obshih_Peremennih.Povorot_Pravo_Global_1 = true;
        }
        else
        {
            klass_Obshih_Peremennih.Povorot_Pravo_Global_1 = false;
        }
        if (!Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.W))
        {
            klass_Obshih_Peremennih.Povorot_Pravo_Global_1 = false;
            klass_Obshih_Peremennih.Povorot_Levo_Global_1 = false;
            klass_Obshih_Peremennih.Povorot_Verh_Global_1 = false;
            klass_Obshih_Peremennih.Povorot_Niz_Global_1 = false;

        }
    }
}
