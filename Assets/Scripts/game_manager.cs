using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public GameObject enemy;
    public int enemy_spawns = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pick random spawn direction
        if (enemy_spawns > 0)
        {
            int spawn_direction = Random.Range(0, 6);
            int spawn_position = 0;
            switch (spawn_direction)
            {
                case 0:
                    spawn_position = Random.Range(-500, 450);
                    Instantiate(enemy, new Vector3(-500f, 10f, spawn_position), Quaternion.identity);
                    enemy_spawns -= 1;
                    break;
                case 1:
                    spawn_position = Random.Range(-400, 500);
                    Instantiate(enemy, new Vector3(spawn_position, 10f, 430f), Quaternion.identity);
                    enemy_spawns -= 1;
                    break;
                case 2:
                    spawn_position = Random.Range(-500, 450);
                    Instantiate(enemy, new Vector3(500f, 10f, spawn_position), Quaternion.identity);
                    enemy_spawns -= 1;
                    break;
                case 3:
                    spawn_position = Random.Range(-400, 500);
                    Instantiate(enemy, new Vector3(spawn_position, 10f, -430f), Quaternion.identity);
                    enemy_spawns -= 1;
                    break;
            }
        }

        //pick random spawn position from the direction picked
        //spawn at position
    }
}
