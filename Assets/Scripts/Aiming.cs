using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Camera gameCamera;
    public Transform objectToMove;

    void Start()
    {     

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            objectToMove.position = hit.point;
        }
    }

}