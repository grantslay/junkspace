using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Self_Destruct : MonoBehaviour
{
    public AudioSource explosionSound;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_Object")
        {
             SceneManager.LoadScene("SceneseforEllie/Scenes/loss");
        }
    }
}