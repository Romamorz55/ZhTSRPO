using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vzriv : MonoBehaviour
{

    private float schetchik_vremeni = 0;
    public AudioClip clip;

    void Start()
    {
        Play_Audio(clip);
    }

    // Update is called once per frame
    void Update()
    {
        schetchik_vremeni += Time.deltaTime;
        if (schetchik_vremeni >= 2f)
        {
            Destroy(gameObject);
        }
    }
    private void Play_Audio(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
