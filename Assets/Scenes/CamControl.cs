using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    public GameObject player;
    Vector3 newPos;
    float scale = 0;
    public GameObject pointerIcon;
    Vector3 mousePos;

    private void Start()
    {
        transform.position = player.transform.position - new Vector3(0,0,-10);
        pointerIcon=  Instantiate(pointerIcon);
        scale = GetComponent<Camera>().orthographicSize;
    }

    private void Update()
    {

        Scroll();
        Click();
    }
    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        newPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, newPos, 4f * Time.deltaTime);
    }

    void Scroll()
    {
        if (Input.mouseScrollDelta.y > 0) scale--;
        if (Input.mouseScrollDelta.y < 0) scale++;
        GetComponent<Camera>().orthographicSize -= (GetComponent<Camera>().orthographicSize - scale) / 10;
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {

            float camZ = Mathf.Abs(GetComponent<Camera>().transform.position.z);
            mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZ);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
           
            pointerIcon.transform.position = mousePos;
            pointerIcon.gameObject.SetActive(false);
            pointerIcon.gameObject.SetActive(true);
        }
    }

   
}
