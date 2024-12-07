using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaPlayer : MonoBehaviour
{
    public int vidaPlayer = 100;
    public Slider barraVidaPlayer;

    // Update is called once per frame
    private void Update()
    {
        barraVidaPlayer.value = vidaPlayer;
        //barraVidaPlayer.GetComponent<Slider>().value = vidaPlayer;

        if (vidaPlayer <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Time.timeScale = 0; // Pausa completamente el juego

    }

}
