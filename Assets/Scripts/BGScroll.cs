using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        MeshRenderer thisMesh = GetComponent<MeshRenderer>();

        Material Mat_1 = thisMesh.materials[0];

        Vector2 offset_1 = Mat_1.mainTextureOffset;

        offset_1.y += Time.deltaTime / 20;

        Mat_1.mainTextureOffset = offset_1;
    }
}
