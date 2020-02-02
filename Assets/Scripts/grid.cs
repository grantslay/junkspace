using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public GameObject[,] Grid;
    public GameObject tile;
    public GameObject capital_ship;
    public GameObject mg_turret;
    public GameObject healthbar;
    int columns, rows;
    Vector3 starting_point = new Vector3(-15f, -2.5f, -31.5f);
    // Start is called before the first frame update
    void Start()
    {
        var capital_ship_size = capital_ship.GetComponent<Renderer>().bounds.size;
        columns = (int)capital_ship_size.x / 8;
        rows = (int)capital_ship_size.z / 10;
        Grid = new GameObject[columns, rows];
        Vector3 current_pos = starting_point;
        for (int i = 0; i < columns; i++)
        {
            current_pos = new Vector3(current_pos.x + 5, current_pos.y, starting_point.z);
            for (int j = 0; j < rows; j++)
            {
                SpawnTile(current_pos, Grid, i, j);
                current_pos = new Vector3(current_pos.x, current_pos.y, current_pos.z + 5);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.tag == "Tile")
                {
                    tile = rayHit.collider.gameObject;
                    Debug.Log("Tile at " + tile.transform.position.x + ", " + tile.transform.position.y + ", " + tile.transform.position.z + "was clicked");
                    for (int i = 0; i < columns; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            if(Grid[i, j].Equals(tile))
                            {
                                Destroy(Grid[i, j].gameObject);
                                Grid[i, j] = Instantiate(mg_turret, new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z), Quaternion.identity);
                                GameObject healthbar_instance = Instantiate(healthbar, new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z), Quaternion.identity);
                                healthbar_instance.GetComponent<healthbar>().target = Grid[i, j];
                                Grid[i, j].GetComponent<mg_turret>().healthbar = healthbar_instance;
                            }
                        }
                    }
                }
            }
        }
    }

    private void SpawnTile(Vector3 current_pos, GameObject[,] Grid, int i, int j)
    {
        Grid[i, j] = Instantiate(tile, current_pos, Quaternion.identity);
        
    }
}
