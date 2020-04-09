using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    private float m_speedRun = 4;

    private int m_diretion;
    // Start is called before the first frame update
    void Start()
    {
        m_diretion = transform.rotation.y == 0 ? -1 : 1;
        //Debug.Log("mouse script start m_diretion:" + m_diretion);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newpos = new Vector2(0, transform.position.y);
        newpos.x = transform.position.x + m_speedRun * Time.deltaTime * m_diretion;
        transform.position = newpos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("MouseScript trigger: " + collision.tag);
        if(collision.tag == "WallMouse")
        {

            float newRotationY = transform.rotation.y == 0 ? 180 : 0;
            transform.rotation = Quaternion.Euler(0, newRotationY, 0);
            m_diretion = transform.rotation.y == 0 ? -1 : 1;
        }
    }
}
