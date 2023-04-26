using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSensor : MonoBehaviour
{
    WaitForSeconds waitForSeconds = new WaitForSeconds(3);
    private void OnEnable()
    {
        StartCoroutine(DurationTime());
    }
    IEnumerator DurationTime()
    {
        while (true)
        {
            yield return waitForSeconds;
            gameObject.SetActive(false);

            StopCoroutine(DurationTime());

            yield return null;
        }
    }
}
