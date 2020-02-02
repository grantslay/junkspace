using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movements : MonoBehaviour
{
    public float moveSpeed;
    public float thrustSpeed;
    // Start is called before the first frame update
    void Start()
    {
	    moveSpeed = 25;
	    thrustSpeed = 100;
        
	//GetComponent<Rigidbody>().drag = 5000;
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
    }
/*
	else
	{
		GetComponent<Rigidbody>().drag = 5000;
		GetComponent<Rigidbody>().AddForce(transform.forward*0);
	}*/
    //}
/*
    void OnMouseDown()
    {
	GetComponent<Rigidbody>().AddForce(transform.forward*thrustSpeed, ForceMode.Impulse);
    }
*/
}
