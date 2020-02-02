using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject target;
    public GameObject laser;
    public float speed = 2;
    public float shootTimer = 1;
    public float health;
    public GameObject Junk_01;
    public GameObject Junk_02;
    public GameObject healthbar;
	public GameObject grid_manager;
    public float maxHealth = 100;
    public float spawnTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        grid_manager = GameObject.FindWithTag("GridManager");
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (target == null)
        {
            target = getTarget(grid_manager);
        }
        else if (spawnTimer <= 0)
        {
            target = getTarget(grid_manager);
        }
        Vector3 targetDirection = target.transform.position - transform.position;
        float rotateStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);


        float step = speed * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, target.transform.position) > 75)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), step);
        }
        else
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                Instantiate(laser, transform.position, transform.rotation);
                shootTimer = 1;
            }
        }

    }

    void spawn_junk()
    {
        //get current position
        Vector3 curr_pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //generate required random values for junk
        System.Random r = new System.Random();
        int junk_type = r.Next(1, 3);
        int num_junk = r.Next(1, 5);

        //release junk onto current position
        if (junk_type == 1)
        {
            Quaternion junk_rot = Quaternion.identity;

            for (int i = 1; i <= num_junk; i++)
            {
                int junk_travel_dist = r.Next(1, 16);
                junk_rot.eulerAngles = new Vector3(0.0f, r.Next(0, 360), 0.0f);
                Instantiate(Junk_01, new Vector3(curr_pos.x, curr_pos.y, curr_pos.z + junk_travel_dist), junk_rot);
            }
        }

        else
        {
            Quaternion junk_rot = Quaternion.identity;

            for (int i = 1; i <= num_junk; i++)
            {
                int junk_travel_dist = r.Next(1, 16);
                junk_rot.eulerAngles = new Vector3(0.0f, r.Next(0, 360), 0.0f);
                Instantiate(Junk_02, new Vector3(curr_pos.x, curr_pos.y, curr_pos.z + junk_travel_dist), junk_rot);
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player_Laser")
        {
            health -= 20;
            Destroy(collider.gameObject);
            Debug.Log(health);

            if (health <= 0f)
            {
                spawn_junk();
                Destroy(this.gameObject);
            }
            Transform bar = healthbar.transform.GetChild(2);
            Transform greenBar = bar.GetChild(0);
            greenBar.localScale = new Vector3((health / maxHealth) * 10, 1f, 1f);
        }

        
    }

    GameObject getTarget(GameObject grid_manager)
	{
		GameObject[,] targets = grid_manager.GetComponent<grid>().Grid;
        int columns = targets.GetLength(0);
        int rows = targets.GetLength(1);

        float min_dist = 1000000f;
        GameObject curr_target = null;

        for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if(targets[i, j] != null && targets[i, j].tag != "Tile")
                {
                    float curr_dist = Vector3.Distance(transform.position, targets[i, j].transform.position);
                    if (curr_dist < min_dist)
                    {
                        min_dist = curr_dist;
                        curr_target = targets[i, j];
                    }
                }
			}
		}

        return curr_target;

	}
}
