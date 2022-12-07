using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redguy : BasePlayer
{
   
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        GameManager.instance.redGuy = this;
        this.enabled = false;
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        this.arrowSprite.SetActive(false);
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //check for input to destroy things 
        //if (Input.GetKeyDown())
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GameManager.instance.blueGuy.enabled)
        {
            GameManager.instance.blueGuy.enabled = true;
            //GameManager.instance.blueGuy.rb.constraints = RigidbodyConstraints2D.None;
            GameManager.instance.blueGuy.arrowSprite.SetActive(true);
            //this.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            this.arrowSprite.SetActive(false);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
