using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public int[,] Grid;
    public GameObject tile;
    public GameObject capital_ship;
    int columns, rows;
    Vector3 starting_point = new Vector3(-15f, -2.5f, -31.5f);
    // Start is called before the first frame update
    void Start()
    {
        var capital_ship_size = capital_ship.GetComponent<Renderer>().bounds.size;
        Debug.Log((int)capital_ship_size.x);
        columns = (int)capital_ship_size.x / 8;
        Debug.Log((int)capital_ship_size.z);
        rows = (int)capital_ship_size.z / 10;
        Grid = new int[columns, rows];
        Vector3 current_pos = starting_point;
        for (int i = 0; i < columns; i++)
        {
            current_pos = new Vector3(current_pos.x + 5, current_pos.y, starting_point.z);
            for (int j = 0; j < rows; j++)
            {
                SpawnTile(current_pos);
                current_pos = new Vector3(current_pos.x, current_pos.y, current_pos.z + 5);
            }
        }
    }

    // Update is called once per frame
    private void SpawnTile(Vector3 current_pos)
    {
        Instantiate(tile, current_pos, Quaternion.identity);
        
    }
}
