using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTemp : MonoBehaviour
{
    public static CameraTemp instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
