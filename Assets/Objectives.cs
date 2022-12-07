using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public bool redObj;
    public bool blueObj;
    public bool mainObj;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("RedGuy") && redObj)
        {
            Destroy(this.gameObject);
            GameManager.instance.objectivesToCollect.Remove(this.transform);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueGuy") && blueObj)
        {
            Destroy(this.gameObject);
            //GameManager.instance.objectivesToCollect--;
            GameManager.instance.objectivesToCollect.Remove(this.transform);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("MainGuy") && mainObj)
        {
            Destroy(this.gameObject);
            //GameManager.instance.objectivesToCollect--;
            GameManager.instance.objectivesToCollect.Remove(this.transform);
        }

    }

}


