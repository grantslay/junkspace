using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float shootTimer = 0.5f;
    public GameObject laser;
    public float junk_counter;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        junk_counter = 0;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Transform spawnPoint = transform.GetChild(1);
                Instantiate(laser, new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z), transform.rotation);
                shootTimer = 0.5f;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy_Laser")
        {
            health -= 5;
            Destroy(collider.gameObject);
            Debug.Log(health);

            if (health >= 0f)
            {
                Destroy(this.gameObject);
            }
        }

        else if (collider.gameObject.tag == "Junk")
        {
            Destroy(collider.gameObject);
            junk_counter += 1;
            Debug.Log("Junk: " + junk_counter);
        }
    }
}
