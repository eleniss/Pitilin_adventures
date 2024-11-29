using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//queremos que este script herede de interactable, por eso cambiamos el monobehaviour a interactable
public class Boton : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact() //diseñamos interacción (cambiar color, abrir algo, lo que sea)
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
