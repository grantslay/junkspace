using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject healthbar;
    public GameObject player;
    public GameObject camera;
    public int enemy_spawns = 15;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player_instance = Instantiate(player, new Vector3(0, 10f, 0), Quaternion.identity);
        GameObject healthbar_instance = Instantiate(healthbar, new Vector3(0, 20f, 0), Quaternion.identity);
        healthbar_instance.GetComponent<healthbar>().target = player_instance;
        GameObject camera_instance = Instantiate(camera, new Vector3(0, 20f, 0), Quaternion.identity);
        camera_instance.GetComponent<camera>().target = player_instance;
    }

    // Update is called once per frame
    void Update()
    {
        //pick random spawn direction
        if (enemy_spawns > 0)
        {
            int spawn_direction = Random.Range(0, 4);
            int spawn_position = 0;
            GameObject enemy_instance;
            GameObject healthbar_instance;
            switch (spawn_direction)
            {
                case 0:
                    spawn_position = Random.Range(-500, 450);
                    enemy_instance = Instantiate(enemy, new Vector3(-500f, 10f, spawn_position), Quaternion.identity);
                    healthbar_instance = Instantiate(healthbar, new Vector3(-500f, 10f, spawn_position), Quaternion.identity);
                    enemy_instance.GetComponent<enemy>().healthbar = healthbar_instance;
                    healthbar_instance.GetComponent<healthbar>().target = enemy_instance;
                    enemy_spawns -= 1;
                    break;
                case 1:
                    spawn_position = Random.Range(-400, 500);
                    enemy_instance = Instantiate(enemy, new Vector3(spawn_position, 10f, 430f), Quaternion.identity);
                    healthbar_instance = Instantiate(healthbar, new Vector3(spawn_position, 10f, 430f), Quaternion.identity);
                    enemy_instance.GetComponent<enemy>().healthbar = healthbar_instance;
                    healthbar_instance.GetComponent<healthbar>().target = enemy_instance;
                    enemy_spawns -= 1;
                    break;
                case 2:
                    spawn_position = Random.Range(-500, 450);
                    enemy_instance = Instantiate(enemy, new Vector3(500f, 10f, spawn_position), Quaternion.identity);
                    healthbar_instance = Instantiate(healthbar, new Vector3(500f, 10f, spawn_position), Quaternion.identity);
                    enemy_instance.GetComponent<enemy>().healthbar = healthbar_instance;
                    healthbar_instance.GetComponent<healthbar>().target = enemy_instance;
                    enemy_spawns -= 1;
                    break;
                case 3:
                    spawn_position = Random.Range(-400, 500);
                    enemy_instance = Instantiate(enemy, new Vector3(spawn_position, 10f, -430f), Quaternion.identity);
                    healthbar_instance = Instantiate(healthbar, new Vector3(spawn_position, 10f, -430f), Quaternion.identity);
                    enemy_instance.GetComponent<enemy>().healthbar = healthbar_instance;
                    healthbar_instance.GetComponent<healthbar>().target = enemy_instance;
                    enemy_spawns -= 1;
                    break;
            }
        }

        //pick random spawn position from the direction picked
        //spawn at position
    }
}
