using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//construct grid of objects that occupies every space
    //should be placed in grid constructor object
    //object should be on the bottom left of the grid being made
    //perspective must remain the same with forward being +X, right being -Z
    //columns pretains to the "vertical rows", rows to the "horizontal rows"
        //feel free to shift these values if you make your own new maze

//Known Bug
    //If the space GridConstructor stands is encased, GridPoint will destroy itself
    //On the next load of Maze1, this will not reload meaning objects like the Roofs that require Gridpoint don't load
public class GridConstructor : MonoBehaviour
{
    public GameObject gridPointPrefab;
    Vector3 startPosition;
    Vector3 shiftedPos;
    int rows = 36;
    int columns = 36;
    float increment = 5f;

    void Start()
    {
        startPosition = transform.position;

        for (int x = 0; x<columns; x++)
        {
            for (int y = 0; y<rows; y++)
            {
                shiftedPos = startPosition;
                float shiftX = increment * x;
                float shiftZ = increment * y * -1; //negative because of positioning of our scene
                Vector3 temp = new Vector3(shiftX, 0, shiftZ);
                shiftedPos += temp;
                
                Instantiate(gridPointPrefab, shiftedPos, Quaternion.identity);
            }
        }
    }
}
