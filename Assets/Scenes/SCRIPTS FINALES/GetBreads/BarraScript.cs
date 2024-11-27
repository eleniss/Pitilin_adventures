using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraScript : MonoBehaviour
{
    public Image foodBar; // Referencia a la imagen de la barra (tipo Filled).
    public float maxFood = 100f; // Máximo valor de comida.
    public float currentFood; // Comida actual.

    void Start()
    {
        currentFood = 0; // Comienza vacía.
        UpdateFoodBar(); // Actualiza la barra.
    }

    public void EatFood(float foodAmount)
    {
        currentFood += foodAmount; // Incrementa comida.
        currentFood = Mathf.Clamp(currentFood, 0, maxFood); // Evita exceder el máximo.
        UpdateFoodBar(); // Actualiza la barra.
    }

    void UpdateFoodBar()
    {
        foodBar.fillAmount = currentFood / maxFood; // Ajusta el valor del fillAmount.
    }
}


