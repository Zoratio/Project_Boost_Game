using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool open = false;


    private void Update()
    {
        if (open)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, new Vector3(door.transform.position.x, 60, door.transform.position.z), Time.deltaTime * 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        open = true;
        transform.position = new Vector3(99, 99, 99);
    }
}
