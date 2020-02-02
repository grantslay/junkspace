using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float shootTimer = 0.5f;
    public GameObject laser;
    public GameObject healthbar;
    public float junk_counter;
    public float maxHealth = 100;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        junk_counter = 0;
        health = maxHealth;
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

            health -= 10;

            Destroy(collider.gameObject);
            Debug.Log(health);

            if (health <= 0f)
            {
                Destroy(this.gameObject);
            }
            Transform bar = healthbar.transform.GetChild(2);
            Transform greenBar = bar.GetChild(0);
            greenBar.localScale = new Vector3((health/maxHealth)*10, 1f, 1f);
        }

        else if (collider.gameObject.tag == "Junk")
        {
            Destroy(collider.gameObject);
            junk_counter += 1;
            Debug.Log("Junk: " + junk_counter);
        }
    }
}
