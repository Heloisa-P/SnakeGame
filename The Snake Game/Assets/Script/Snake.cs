using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;

    private Vector2 dir = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private bool ate = false;

    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.1f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //food?
        if (coll.name.StartsWith("food"))
        {
            ate = true;
            Destroy(coll.gameObject);
        }
        else
        {
            //TODO: Lose Screen
        }
    }

    private void Move()
    {

        //where the head was
        Vector2 v = transform.position;

        //move the head
        transform.Translate(dir * 0.35f);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }

        //Do we have a tail
        else if (tail.Count > 0)
        {
            //move the last tail to where the head was
            tail.Last().position = v;

            //add to the front of the list and remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}
