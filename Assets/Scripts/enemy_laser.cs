﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_laser : MonoBehaviour
{

    public float shootingSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * shootingSpeed;
    }
}
