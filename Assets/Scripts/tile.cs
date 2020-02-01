using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color oldCol = gameObject.GetComponent<Renderer>().material.color;
        Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, 0.25f);
        gameObject.GetComponent<Renderer>().material.color = newCol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
