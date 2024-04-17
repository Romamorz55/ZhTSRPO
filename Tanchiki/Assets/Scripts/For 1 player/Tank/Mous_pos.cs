using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mous_pos : MonoBehaviour
{
    public Klass_Obshih_Peremennih ssilka_na_Klass_Obshih;
    private Vector3 LastMousPos;
    private int width_okna;
    private int hight_okna;
    private float gradus_1_po_width;
    private float gradus_1_po_higth;
    private float seredina_po_width;
    //private float gorizont_po_heigth;
    private float ugol_levo_pravo;
    private float ugol_Verh_niz;


    void Start()
    {
        width_okna = Screen.width;
        hight_okna = Screen.height;
        //gradus_1_po_higth = (float)hight_okna / 45;
        gradus_1_po_width = (float)width_okna / 170; //85 градусов в каждую сторону
        seredina_po_width = (float)width_okna / 2;
        //gorizont_po_heigth = 10 * gradus_1_po_higth;
    }


    void Update()
    {
        Opredelenie_Koord_Mouse();

    }
    private void Opredelenie_Koord_Mouse()
    {

        float x = Input.mousePosition.x + 0.1f;//чтобы не стоял ровно посередине (проблема с 360 градусов)
        float y = Input.mousePosition.y + 0.1f;
        if (x > Screen.width | y > Screen.height | x < 0 | y < 0)
        {
            return;
        }
        if (x <= seredina_po_width)
        {
            ugol_levo_pravo = 360 - ((seredina_po_width - x) / gradus_1_po_width);
        }
        else
        {
            ugol_levo_pravo = (x - seredina_po_width) / gradus_1_po_width;
        }
       
        ssilka_na_Klass_Obshih.ugol_horizont_Pushki = ugol_levo_pravo;
    }
}
