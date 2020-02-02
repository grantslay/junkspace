using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movements : MonoBehaviour
{
    public float moveSpeed;
    public float thrustSpeed;
    public float junk_counter;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
	    moveSpeed = 25;
	    thrustSpeed = 100;
	    junk_counter = 0;
	    health = 100;
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy_Laser")
        {
            health -= 5;
            Destroy(collider.gameObject);
            Debug.Log(health);
            
            if(health == 0)
            {
                Destroy(this.gameObject);
            }
        }
        
        else if (collider.gameObject.tag == "Junk")
        {
        	Destroy(collider.gameObject);
        	junk_counter++;
    	}
    }
}
