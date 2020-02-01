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
	moveSpeed = 5f;
	thrustSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
	transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);

	if (Input.GetKeyDown(KeyCode.W))
	{
	    this.GetComponent<Rigidbody>().AddForce(transform.forward*thrustSpeed);
	}
    }
}
