using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTExplod : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(SetHideTXTExplod());
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TNTExplod OnTriggerEnter2D: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Diamond" || collision.gameObject.tag == "MouseDiamond" || collision.gameObject.tag == "Mouse"
            || collision.gameObject.tag == "goldBig" || collision.gameObject.tag == "GoldNormal" || collision.gameObject.tag == "GoldSmall"
            || collision.gameObject.tag == "StoneNormal" || collision.gameObject.tag == "StoneSmall")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "TNT")
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.CreateTNTExplod(collision.gameObject.transform.position);
        }
    }
    IEnumerator SetHideTXTExplod()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
