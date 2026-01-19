using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour
{
    Light light;

    void Start() {
        light = GetComponent<Light>();
        InvokeRepeating("Flicker", 0, 2f);
    }

    void Flicker() {
        StartCoroutine(FlickerSequence());
    }

    IEnumerator FlickerSequence() {
        light.intensity = 0.3f;
        yield return new WaitForSeconds(0.15f);
        light.intensity = 1f;
        yield return new WaitForSeconds(0.15f);
        light.intensity = 0.4f;
        yield return new WaitForSeconds(0.15f);
        light.intensity = 1f;
        yield return new WaitForSeconds(0.15f);
        light.intensity = 0.5f;
        yield return new WaitForSeconds(0.15f);
        light.intensity = 1f;
    }
}
