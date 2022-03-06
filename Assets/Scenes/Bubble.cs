using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1) * Random.Range(0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
