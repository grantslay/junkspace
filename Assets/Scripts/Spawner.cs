using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjToBeSpawned;
    public GameObject ObjToBeSpawned2;

    private int quikTime;
    private int halfTime;

    // Update is called once per frame
    void Update()
    {

        if (Time.frameCount % 60 == 0) // every second at 60 fps
        {
            float position = Random.Range(-10f , 10f);
            Instantiate(ObjToBeSpawned, new Vector3(position, 6f, 0f), Quaternion.identity);
        }

        if ((int)Time.time != quikTime) // every second at 60 fps
        {
            float position = Random.Range(-10f, 10f);
            Instantiate(ObjToBeSpawned2, new Vector3(position, 6f, 0f), Quaternion.identity);
        }

        quikTime = (int)Time.time;
    }
}
