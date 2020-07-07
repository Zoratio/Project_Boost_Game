using UnityEngine;

public class SetTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Timer", 0f);
    }
}
