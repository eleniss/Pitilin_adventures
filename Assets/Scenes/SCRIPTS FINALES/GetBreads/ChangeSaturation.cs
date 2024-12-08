using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class ChangeSaturation : MonoBehaviour
{
    // Start is called before the first frame update
    public Material _materialFullScreen;
    private float destructionCount = 0f;
    private float maxSat = 100f;
    private float minSat = 0f;

    public void OnObjectDestroyed()
    {
        destructionCount = Mathf.Min(destructionCount + 5f, maxSat);

        _materialFullScreen.SetFloat("_saturation", destructionCount);

    }

    public void ResetSat()
    {
        destructionCount = Mathf.Min(destructionCount - 1f, minSat);
        _materialFullScreen.SetFloat("_saturation", destructionCount);
    }


}
