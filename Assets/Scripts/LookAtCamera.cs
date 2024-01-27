using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private SpriteRenderer theSR;
    
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CameraTemp.instance.transform.position, -Vector3.back);
    }
}
