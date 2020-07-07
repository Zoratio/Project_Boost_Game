using System.Collections;
using UnityEngine;

public static class FadeAudioSource
{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        yield return new WaitForSeconds(0.2f);

        while (currentTime < duration)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                audioSource.volume = 1.0f;
                yield break;
            }
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);            
            yield return null;
        }
        audioSource.Stop();
        yield break;
    }
}