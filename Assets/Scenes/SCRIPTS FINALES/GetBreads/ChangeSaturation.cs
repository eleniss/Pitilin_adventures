using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class ChangeSaturation : MonoBehaviour
{
    // Start is called before the first frame update
    public PostProcessVolume _PostProcessVol;
    private ColorGrading _colorGrading;
    void Start()
    {
        if(_PostProcessVol.profile.TryGetSettings(out _colorGrading))
        {
            _colorGrading.saturation.value = 0;
        }
    }

    // Update is called once per frame
    public void CambioSaturacion(float newSat)
    {
        _colorGrading.saturation.value = newSat;
    }
}
