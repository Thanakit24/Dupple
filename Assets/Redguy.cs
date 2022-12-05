using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redguy : BasePlayer
{
   
    public override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        GameManager.instance.redGuy = this;
        this.enabled = false; 
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //check for input to destroy things 
        //if (Input.GetKeyDown())
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GameManager.instance.blueGuy.enabled)
        {
            GameManager.instance.blueGuy.enabled = true;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
