using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScale : MonoBehaviour
{

    Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        myCam.orthographicSize = Camera.main.orthographicSize;
    }
}
