using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mous_pos_0 : MonoBehaviour
{
    public Klass_Obshih_Peremennih_2 ssilka_na_Klass_Obshih;
    private Vector3 LastMousPos;
    private int width_okna_0;
    private int hight_okna_0;
    private float gradus_1_po_width_0;
    private float gradus_1_po_higth_0;
    private float seredina_po_width_0;
    //private float gorizont_po_heigth;
    private float ugol_levo_pravo_0;
    private float ugol_Verh_niz_0;


    void Start()
    {
        width_okna_0 = Screen.width;
        hight_okna_0 = Screen.height;
        //gradus_1_po_higth = (float)hight_okna / 45;
        gradus_1_po_width_0 = (float)width_okna_0 / 170; //85 градусов в каждую сторону
        seredina_po_width_0 = (float)width_okna_0 / 2;
        //gorizont_po_heigth = 10 * gradus_1_po_higth;
    }


    void Update()
    {
        Opredelenie_Koord_Mouse_0();

    }
    private void Opredelenie_Koord_Mouse_0()
    {

        float x = Input.mousePosition.x + 0.1f;//чтобы не стоял ровно посередине (проблема с 360 градусов)
        float y = Input.mousePosition.y + 0.1f;
        if (x > Screen.width | y > Screen.height | x < 0 | y < 0)
        {
            return;
        }
        if (x <= seredina_po_width_0)
        {
            ugol_levo_pravo_0 = 360 - ((seredina_po_width_0 - x) / gradus_1_po_width_0);
        }
        else
        {
            ugol_levo_pravo_0 = (x - seredina_po_width_0) / gradus_1_po_width_0;
        }
       
        ssilka_na_Klass_Obshih.ugol_horizont_Pushki = ugol_levo_pravo_0;
    }
}
