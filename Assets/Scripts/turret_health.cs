using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_health : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = healthbar.transform.GetChild(2);
        Transform greenBar = bar.GetChild(0);
        greenBar.localScale = new Vector3((health / maxHealth) * 10, 1f, 1f);
    }

    private void OnTriggerEnter(Collider enemy_projectile)
    {
        if (enemy_projectile.gameObject.tag == "Enemy_Laser")
        {
            health -= 25;
            Destroy(enemy_projectile.gameObject);
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            
        }
    }


}
