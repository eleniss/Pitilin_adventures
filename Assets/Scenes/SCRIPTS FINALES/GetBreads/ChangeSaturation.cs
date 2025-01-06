using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;


public class ChangeSaturation : MonoBehaviour
{
    public Volume globalVolume;
    private ColorAdjustments colorAdjustments;
    private float destructionCount = 0f;
    private float maxSat = 100f;
    private float minSat = -20f;

    void Start()
    {
        if (globalVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            colorAdjustments.saturation.value = minSat;
        }
    }

    public void CambiarSaturacion()
    {
        destructionCount = Mathf.Min(destructionCount + 20f, maxSat);

        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = destructionCount;
        }
    }
    public void ResetSat()
    {
        destructionCount = Mathf.Max(destructionCount - 20f, minSat);

        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = destructionCount;
        }
    }

}
