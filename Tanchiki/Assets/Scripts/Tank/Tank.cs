using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_2 : MonoBehaviour
{
    private GameObject _obsh_Perem;
    private GameObject bashnya_tanka;
    private GameObject pushka_Fiktivnaya_tanka;
    private GameObject pushka_tanka;
    private GameObject camera_pushki;
    private GameObject camera_zadnego_vida;

    public GameObject snaryad_abstrakt;
    private float moshnost_Vistrela = 40f;
    public AudioClip clip_vistrel;
    public bool najata_knopka_vistrel = false;
    private bool vistrel_razreshen = true;
    private float schetchik_vremya_mejdu_Vestrelami = 0f;
    public float vremya_mejdu_Vestrelami = 1.5f;


    void Start()
    {
        _obsh_Perem = GameObject.Find("___obsch_obect");

        bashnya_tanka = transform.GetChild(0).gameObject;

        pushka_Fiktivnaya_tanka = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        pushka_tanka = pushka_Fiktivnaya_tanka.transform.GetChild(0).gameObject;
        camera_zadnego_vida = transform.GetChild(1).gameObject;
        camera_pushki = pushka_tanka.transform.GetChild(0).gameObject;
        pushka_Fiktivnaya_tanka.transform.Rotate(-10f, 0, 0, Space.Self);
    }

    void Update()
    {
        Perekluchenie_Kameri();
        Povorot_Bashni_i_Pushki();
        Proverka_na_Vistrel();
    }

    private void Povorot_Bashni_i_Pushki()
    {
        bashnya_tanka.transform.localEulerAngles = new Vector3(0, _obsh_Perem.GetComponent<Klass_Obshih_Peremennih>().ugol_horizont_Pushki);
        pushka_Fiktivnaya_tanka.transform.localEulerAngles = new Vector3(_obsh_Perem.GetComponent<Klass_Obshih_Peremennih>().ugol_vert_Pushki, 0);

    }
    private void Perekluchenie_Kameri()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (camera_pushki.GetComponent<Camera>().depth == 0)
            {
                camera_pushki.GetComponent<Camera>().depth = 1;
                camera_zadnego_vida.GetComponent<Camera>().depth = 0;
            }
            else
            {
                camera_pushki.GetComponent<Camera>().depth = 0;
                camera_zadnego_vida.GetComponent<Camera>().depth = 1;
            }
        }
    }

    private void Proverka_na_Vistrel()
    {
        if (Input.GetMouseButtonDown(0))
        {
            najata_knopka_vistrel = true;
        }
        else
        {
            najata_knopka_vistrel = false;
        }
        schetchik_vremya_mejdu_Vestrelami += Time.deltaTime;
        if (schetchik_vremya_mejdu_Vestrelami >= _obsh_Perem.GetComponent<Klass_Obshih_Peremennih>().vremya_mejdu_Vestrelami)
        {
            vistrel_razreshen = true;

        }
        if (najata_knopka_vistrel & vistrel_razreshen)
        {
            Vistrel_Snaryada();
            vistrel_razreshen = false;
            schetchik_vremya_mejdu_Vestrelami = 0;

        }

    }

    private void Vistrel_Snaryada()
    {
        GameObject snaryad = Instantiate(snaryad_abstrakt) as GameObject;
        snaryad.transform.position = pushka_tanka.transform.position;
        snaryad.transform.rotation = pushka_tanka.transform.rotation;
        snaryad.transform.Translate(0.4f, 0f, 2f, Space.Self);
        snaryad.GetComponent<Rigidbody>().AddRelativeForce(snaryad.transform.forward * moshnost_Vistrela, ForceMode.VelocityChange);
        Play_Audio(clip_vistrel);


    }
    private void Play_Audio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
