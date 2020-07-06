using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLightRotation : MonoBehaviour
{
    Vector3 iniPos;
    Quaternion iniRot;
 
    void Start()
    {
        iniPos = transform.position;

        iniRot = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = iniPos;

        transform.rotation = iniRot;
    }
}
