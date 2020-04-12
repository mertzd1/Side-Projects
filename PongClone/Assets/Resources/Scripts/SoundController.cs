using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallsound;

    public AudioSource raquetSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player1" || collision.gameObject.name == "Player2")
        {
            this.raquetSound.Play();
        }
        else
        {
            this.wallsound.Play();
        } 
    }
}
