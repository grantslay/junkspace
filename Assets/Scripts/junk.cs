using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk : MonoBehaviour
{
	public float junk_travel_dist;
	public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        junk_travel_dist = Random.Range(1,16);
    }

    // Update is called once per frame
    void Update()
    {
		if (Vector3.Distance(transform.position, player.transform.position) > 20)
		{
		    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3 * Time.deltaTime);
		}
		
		else if (junk_travel_dist > 0)
    	{
    		transform.position += transform.forward * Time.deltaTime * 3;
    		junk_travel_dist--;
		}
    }
}
