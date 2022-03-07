using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Vector3 originalPos;
    Transform playerTrans;
    float dist;
    Vector3 dir;
    float moveAway = 0;
    Vector3 currentPos, newPos;
    float dt;
    float radius;
    
    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        originalPos = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0 ) ;
        transform.localScale = new Vector3(1, 1, 1) * Random.Range(0.1f, 0.5f);
        newPos = currentPos = transform.position;
        radius = Random.Range(2f, 4f);
        transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }
    Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        offset = new Vector3( Mathf.Cos(originalPos.x + Time.time * 1)/1.2f, Mathf.Cos(originalPos.y + Time.time * 2)/1.5f, 0  ); 
        dt = Time.deltaTime;
        dist = Vector2.Distance(transform.position,playerTrans.position);
        if(dist > radius)
        {

            newPos = originalPos;
        }
        else
        {
           
            dir = playerTrans.position - transform.position;
            newPos = transform.position - dir*2;
        }


        currentPos -= (currentPos - (newPos + offset)) / 0.2f * dt;
        transform.position -= (transform.position - currentPos) / 1f * dt;
    }
}
