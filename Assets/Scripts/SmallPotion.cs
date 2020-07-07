using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmallPotion : MonoBehaviour
{
    bool small = false;
    float timer = 20f;
    [SerializeField] Light sl;
    [SerializeField] GameObject rocket;
    [SerializeField] TextMeshProUGUI txtCountDown;

    float x;
    float y;
    float z;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    private void OnTriggerEnter(Collider other)
    {        
        small = true;
        StartCoroutine(SmallState());
        StartCoroutine(CountDownText());

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

    IEnumerator CountDownText()
    {
        txtCountDown.gameObject.SetActive(true);
        txtCountDown.text = "10";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "9";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "8";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "7";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "6";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "5";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "4";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "3";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "2";
        yield return new WaitForSeconds(1f);
        txtCountDown.text = "1";
        yield return new WaitForSeconds(1f);
        txtCountDown.gameObject.SetActive(false);
    }
}
