using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Enemy: MonoBehaviour
{
    private GameObject _obsh_Perem;
    private GameObject bashnya_tanka;
    private GameObject pushka_Fiktivnaya_tanka;
    private GameObject pushka_tanka;

    public GameObject snaryad_abstrakt;
    private float moshnost_Vistrela = 40f;
    public AudioClip clip_vistrel;
    private bool vistrel_razreshen = true;
    private float schetchik_vremya_mejdu_Vestrelami = 0f;
    public float vremya_mejdu_Vestrelami = 3f;


    void Start()
    {
        _obsh_Perem = GameObject.Find("___Tank_Enemy");

        bashnya_tanka = transform.GetChild(0).gameObject;

        pushka_Fiktivnaya_tanka = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        pushka_tanka = pushka_Fiktivnaya_tanka.transform.GetChild(0).gameObject;
        pushka_Fiktivnaya_tanka.transform.Rotate(0f, 0, 0, Space.Self);
    }

    void Update()
    {
        Vistrel();
    }

    private void Vistrel()
    {
        schetchik_vremya_mejdu_Vestrelami += Time.deltaTime;

        if (schetchik_vremya_mejdu_Vestrelami >= vremya_mejdu_Vestrelami)
        {
            vistrel_razreshen = true;

        }
        if (vistrel_razreshen)
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
        snaryad.transform.Translate(-3f, 0f, 2f, Space.Self);
        snaryad.GetComponent<Rigidbody>().AddRelativeForce(snaryad.transform.forward * moshnost_Vistrela, ForceMode.VelocityChange);
        Play_Audio(clip_vistrel);


    }
    private void Play_Audio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
