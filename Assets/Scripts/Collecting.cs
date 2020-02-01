using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            collectSound.Play();
            Scoring.score += Scoring.scoreValue;
            Destroy(gameObject);
        }

        else
        {
            //gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(Instantaneous_Velocity.Instant_V.x, Instantaneous_Velocity.Instant_V.y);
        }
    }
}
