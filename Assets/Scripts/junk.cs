using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junk : MonoBehaviour
{
	public int junk_travel_dist;
	public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        junk_travel_dist = Random.Range(200, 300);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (Vector3.Distance(transform.position, player.transform.position) < 40)
		{
		    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 20 * Time.deltaTime);
		}
		
		else if (junk_travel_dist > 0)
    	{
    		transform.position += transform.forward * Time.deltaTime * 1;
    		junk_travel_dist -= 1;
		}
    }
}
