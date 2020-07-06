﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : MonoBehaviour
{
    bool small = false;
    float timer = 20f;
    [SerializeField] Light sl;
    [SerializeField] GameObject rocket;

    float x;
    float y;
    float z;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    private void Update()
    {
        if (small)
        {

        }    
    }


    private void OnTriggerEnter(Collider other)
    {        
        small = true;
        StartCoroutine(SmallState());
    }

    IEnumerator SmallState()
    {
        transform.position = new Vector3(99, 99, 99);
        rocket.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sl.gameObject.transform.localPosition = new Vector3(0f, 0f, -8f);
        yield return new WaitForSeconds(10);
        rocket.gameObject.transform.localScale = new Vector3(1,1,1);
        sl.gameObject.transform.localPosition = new Vector3(0f, 0f, -4.7f);

        transform.position = new Vector3(x, y, z);
    }
}
