using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klass_Obshih_Peremennih_2 : MonoBehaviour
{
    public bool Povorot_Levo_Global = false;
    public bool Povorot_Verh_Global = false;
    public bool Povorot_Pravo_Global = false;
    public bool Povorot_Niz_Global = false;
    public float vremya_mejdu_Vestrelami = 1.5f;
    //-----------------------------------------

    public float ugol_vert_Pushki;
    public float ugol_horizont_Pushki;

    public AudioSource audioSource;
    public AudioClip clip_tank_destroy;

    public void Zvuk_Razrusheniya_tanka()
    {
        Play_Audio(clip_tank_destroy);
    }
    private void Play_Audio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
