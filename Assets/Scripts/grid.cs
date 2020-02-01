using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public int[,] Grid;
    public GameObject tile;
    int vertical, horizontal, columns, rows;
    Camera camera;
    Vector3 starting_point = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        horizontal = 10;
        vertical = 10;
        columns = horizontal * 2;
        rows = vertical * 2;
        Grid = new int[columns, rows];
        Vector3 current_pos = starting_point;
        for (int i = 0; i < columns; i++)
        {
            current_pos = new Vector3(current_pos.x + 5, current_pos.y, starting_point.z);
            for (int j = 0; j < rows; j++)
            {
                SpawnTile(i, j, current_pos);
                current_pos = new Vector3(current_pos.x, current_pos.y, current_pos.z + 5);
            }
        }
    }

    // Update is called once per frame
    private void SpawnTile(int x, int y, Vector3 current_pos)
    {
        Instantiate(tile, current_pos, Quaternion.identity);
        
    }
}
