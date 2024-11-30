using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class DissolveEffect : MonoBehaviour
{
    private Material material;
    private float dissolveAmount = 0;

    void Start()
    {
        material = GetComponent<Renderer>().material; // Get the material
    }

    public void StartDissolve(float duration)
    {
        StartCoroutine(DissolveCoroutine(duration));
    }

    private IEnumerator DissolveCoroutine(float duration)
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            dissolveAmount = Mathf.Lerp(0, 1, elapsed / duration); // Increase dissolve amount over time
            material.SetFloat("_DissolveAmount", dissolveAmount);
            elapsed += Time.deltaTime;
            yield return null;
        }

        dissolveAmount = 1;
        material.SetFloat("_DissolveAmount", dissolveAmount);

        Destroy(gameObject); // Destroy the object after dissolving
    }
}


