using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audios;
    AudioSource source;

    float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            if (timer <= 0f)
            {
                source.PlayOneShot(audios[Random.Range(0, audios.Length)]);
                timer = 5f;
            }
            else
                timer -= Time.deltaTime;
        }
    }
}
