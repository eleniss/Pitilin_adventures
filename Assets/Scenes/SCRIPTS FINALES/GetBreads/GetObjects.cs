using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjects : MonoBehaviour
{
    // Start is called before the first frame update
    public BarraScript foodBar; // Referencia al script de la barra de comida.

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GoodBread"))
        {
            Destroy(other.gameObject);

            foodBar.EatFood(10f); // Incrementa la barra en 10 unidades.

        }
    }
}
