using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public GameObject target;
    public GameObject laser;
    public float speed = 2;
    public float shootTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        
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
                shootTimer = 3;
            }
        }

    }
}
