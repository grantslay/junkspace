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

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        float rotateStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);


        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.transform.position) > 75)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.transform.position, step);
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
		
		if (health <= 0.0)
		{
			spawn_junk();
			Destroy(this.gameObject);
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
		//send junk in random direction
}
