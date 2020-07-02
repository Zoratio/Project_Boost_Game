using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField] GameObject rock; 
    bool triggered = false; 


    private void Update()
    {
        if (triggered)
        {
            rock.transform.position = Vector3.MoveTowards(rock.transform.position, new Vector3(rock.transform.position.x, -10, rock.transform.position.z), Time.deltaTime * 10f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        transform.position = new Vector3(-99, -99, -99);
    }
}
