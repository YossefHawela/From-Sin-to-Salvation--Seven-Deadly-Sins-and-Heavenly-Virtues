using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lighto : MonoBehaviour
{
    [SerializeField] private Light2D light;
    bool night = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Day());
    }

    IEnumerator Night() 
    {
        while (night)
        {
            yield return new WaitForSeconds(10f);
            light.intensity += 0.007f;
            if (light.intensity == 1 || light.intensity > 1)
                break;
        }

        night = false;
        StartCoroutine(Day());
    }

    IEnumerator Day()
    {
        while (!night)
        {
            yield return new WaitForSeconds(10f);
            light.intensity -= 0.007f;

            if (light.intensity == 0.5 || light.intensity < 0.5)
                break;
        }

        night = true;
        StartCoroutine(Night());
    }
}
