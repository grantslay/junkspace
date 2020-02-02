using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movements : MonoBehaviour
{
    public float moveSpeed;
    public float thrustSpeed;
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
	    moveSpeed = 25;
	    thrustSpeed = 100;
        rotation = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(0f, rotation - 2, 0f);
            transform.rotation = rot;
            rotation -= 2;
        }

        if (Input.GetKey("d"))
        {
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(0f, rotation + 2, 0f);
            transform.rotation = rot;
            rotation += 2;
        }

    }
    
}
