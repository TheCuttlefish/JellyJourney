using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jelly : MonoBehaviour
{


    Rigidbody2D rb;
    public AnimationCurve pulse;
    Vector3 mousePos;
    float boost;
    float uniqueFactor;
    const float maxboost = 30;
    float scale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uniqueFactor = Random.Range(0.0f, 1f);
    }

    private void Update()
    {

        scale = 1 + pulse.Evaluate(Time.time % 1) * 3;
        transform.localScale = new Vector3(scale, scale, scale);
        
       // Trail();
        LookAtMouse();
        float camZ = Mathf.Abs(Camera.main.transform.position.z);
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZ);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            boost = maxboost;
        }

        if (Input.GetMouseButtonDown(1))
        {
            boost = -maxboost;
        }




        ShowDamage();

    }
    void FixedUpdate()
    {
        boost -= (boost - 0) / 15;
        float dist = Vector2.Distance(transform.position, mousePos);
        rb.AddForce((transform.up) * boost * dist); // force based on dist
        
    }

    void LookAtMouse()
    {

        var camZ = Mathf.Abs(Camera.main.transform.position.z);
        var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZ);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.up = -(transform.position - mousePos);
    }

    bool showDamage;

    public void Damage()
    {
        showDamage = true;
        damageTime = 1.2f;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public float damageTime = 0;
    void ShowDamage()
    {
        if (showDamage)
        {
            damageTime -= 1f * Time.deltaTime;
            if(damageTime < 0)
            {
                damageTime = 0;
                showDamage = false;
            }
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, new Color(1, 1, 1, 1), 1 -damageTime);
        }
    }

    //public GameObject trail;
    /*
    void Trail()
    {

        Vector3 rot = transform.localEulerAngles;
        GameObject t = Instantiate(trail, transform.position, Quaternion.identity);
        t.GetComponent<Trail>().SetRot(transform.localEulerAngles.z);

    }
    */

}
