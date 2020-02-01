using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform objectToMove;
    public Camera gameCamera;

    void Update()
    {
        Vector2 position = gameCamera.ScreenToWorldPoint(Input.mousePosition);

        objectToMove.transform.position = position;
    }
}
