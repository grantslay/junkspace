using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_health : MonoBehaviour
{

    public int health = 500;

    public GameObject healthbar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
