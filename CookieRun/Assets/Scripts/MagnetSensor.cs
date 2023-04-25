using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSensor : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DurationTime());
    }
    IEnumerator DurationTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);

            StopCoroutine(DurationTime());

            yield return null;
        }
    }
}
