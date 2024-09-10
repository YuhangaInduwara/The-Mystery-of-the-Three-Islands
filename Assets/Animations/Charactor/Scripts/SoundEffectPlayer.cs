using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip walk, sfx2, sfx3;

    public void Walking()
    {
        src.clip=walk;
        src.Play();
    }
    public void Running()
    {
        src.clip = sfx2;
        src.Play();
    }
}
