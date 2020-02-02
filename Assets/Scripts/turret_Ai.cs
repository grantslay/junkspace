
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_Ai : MonoBehaviour
{

    public GameObject projectile;
    private GameObject Target;

    private Transform from;
    private Transform to;

    private Queue<GameObject> Targets;

    //private Animator Gunny;

    private float shootTimer = 1f;

    public int damage = 10;
    public float fire_rate = 1f;
    public float speed = 75f;

    // Start is called before the first frame update
    void Start()
    {
        Target = null;
        Targets = new Queue<GameObject>();
    }

    ~turret_Ai()
    {
        Targets.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //Gunny = gameObject.GetComponent<Animator>();

        if (Target != null)
        {
            //Attack();

            // allows for enemy targeting, by obtaining position
            Vector3 targetDirection = Target.transform.position - transform.position;
            float rotateStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotateStep, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);


            // Limits turret rotation speed
            /*
            from.rotation = transform.rotation;
            to.rotation = Quaternion.LookRotation(newDirection);
            float rot_speed = 0.25f;
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * rot_speed);
            */

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                //Gunny.SetBool("Firing", true);
                projectile.GetComponent<enemy_laser>().damage = 10;
                Instantiate(projectile, transform.position + new Vector3(0,0,0), transform.rotation);
                shootTimer = fire_rate;
            }

            else
            {
                //Gunny.SetBool("Firing", false);
            }
        }

        else
        {
            Target = Targets.Dequeue();
            Targets.TrimExcess();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "Hostile") & (Target == null))
        {
            Debug.Log("hit detected");
            Target = other.gameObject;
        }
        else if((other.gameObject.tag == "Hostile") & (Target != null))
        {
            Targets.Enqueue(other.gameObject);
        }
    }

    //private Vector3 find_direction(GameObject Target , GameObject Self)
    //{
    //    return Target.transform.position - Self.transform.position;
    //}


}
