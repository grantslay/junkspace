using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_core : MonoBehaviour
{
    public float maxHealth = 1000;
    public float health;
    public GameObject healthbar;
    public GameObject game_manager;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("GameManager");
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = healthbar.transform.GetChild(2);
        Transform greenBar = bar.GetChild(0);
        greenBar.localScale = new Vector3((health / maxHealth) * 10, 1f, 1f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy_Laser")
        {
            health -= 25;
            Destroy(collider.gameObject);
            Debug.Log(health);

            if (health <= 0f)
            {
                game_manager.GetComponent<game_manager>().power_core_count -= 1;
                Destroy(this.gameObject);
               
            }
            
        }

    }
}
