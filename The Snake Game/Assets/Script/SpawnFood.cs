using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    private void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    private void Spawn()
    {
        //some position in the x axis
        float x = Random.Range(borderLeft.position.x, borderRight.position.x);

        //some position in the y axis
        float y = Random.Range(borderTop.position.y, borderBottom.position.y);

        //instantiate the food
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //Quaternion means default rotation
    }
}
