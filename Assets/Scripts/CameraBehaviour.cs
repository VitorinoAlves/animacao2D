﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBehaviour : MonoBehaviour
{
    public Transform ObjASeguir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ObjASeguir.position.x, ObjASeguir.position.y, transform.position.z);

    }
}
