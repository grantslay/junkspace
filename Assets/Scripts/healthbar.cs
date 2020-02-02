using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != target.transform.position.x || transform.position.y != target.transform.position.y + 3 || transform.position.z != target.transform.position.z + 4.5f)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 3, target.transform.position.z + 4.5f);
        }
    }
}
