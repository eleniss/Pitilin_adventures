using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodBread : MonoBehaviour, ITakeBread
{
    public Image foodBar; 
    private float maxFood = 100f; 
    private float currentFood; 

    void Start()
    {
        currentFood = 0; 
        UpdateFoodBar(); 
    }

    public void EatBread(float amount)
    {
        currentFood += amount; 
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
        UpdateFoodBar(); 
    }

    void UpdateFoodBar()
    {
        foodBar.fillAmount = currentFood / maxFood; 
    }
}


