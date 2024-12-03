using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; //IMPORTANT, coger el del Engine

public class EdgePatrol : MonoBehaviour
{
    public Transform DetectionPoint; //de aqui solo tengo uno enfrente. podria tener más (alrededor del personaje)
    public float speed = 5;
    public LayerMask WhatIsGround;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EdgeDetected())
        {
            Move();
        }
        Turn();
    }

    private bool EdgeDetected()
    {
        return Physics.Raycast(DetectionPoint.position, Vector3.down, 15.15f, WhatIsGround);      //cojo la posicion del detection point, luego su direccion y luego la distancia a del suelo, para evitar que no caiga y finalmente que lo que vea sea el suelo.
    }

    private void Turn()
    {
        transform.Rotate(new Vector3(0, Random.Range(90, 270), 0)); //solo queremos rotacion sobre eje Y
    }

    private void Move()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
