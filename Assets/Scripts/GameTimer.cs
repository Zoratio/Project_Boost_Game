using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;

    // Update is called once per frame
    void Update()
    {
        timer.text = "Timer: " + Rocket.timer;
    }
}
