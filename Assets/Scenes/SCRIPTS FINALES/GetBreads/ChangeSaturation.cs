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
    private float _currentSat = -20f;
    void Start()
    {
        if(_PostProcessVol.profile.TryGetSettings(out _colorGrading))
        {
            _currentSat = _colorGrading.saturation.value;
        }
    }

    // Update is called once per frame
    public void CambioSaturacion(float newSat)
    {
        if(_colorGrading != null)
        {
            _currentSat += newSat;
            _currentSat = Mathf.Clamp(_currentSat, -100f, 100f);

            _colorGrading.saturation.value = _currentSat;

        }
    }
}
