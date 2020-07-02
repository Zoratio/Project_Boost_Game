using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    BoxCollider mc;
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 40, transform.position.z), Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        mc.enabled = false;
    }
}
