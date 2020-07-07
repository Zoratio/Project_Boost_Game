using UnityEngine;

public class PickupRotation : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 20, 0)); 
    }
}
