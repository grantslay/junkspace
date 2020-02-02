using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion qut = Quaternion.identity;
        qut.eulerAngles = new Vector3(60f, 0f, 0f);
        transform.rotation = qut;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != target.transform.position.x || transform.position.y != target.transform.position.y + 34 || transform.position.z != target.transform.position.z - 32)
        {
            transform.position = new Vector3(target.transform.position.x , target.transform.position.y + 34, target.transform.position.z - 20);
        }
    }
}
