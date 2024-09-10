using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip walk, run, jump,sword,shealth;

    public void Walking()
    {
        src.clip=walk;
        src.Play();
    }
    public void Running()
    {
        src.clip = run;
        src.Play();
    }
    public void Jump()
    {
        src.clip = jump;
        src.Play();
    }
    public void Swords()
    {
        src.clip = sword;
        src.Play();
    }
    public void Shealth()
    {
        src.clip = shealth;
        src.Play();
    }
}
