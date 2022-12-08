using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redguy : BasePlayer
{
    public float combineDistance = 3f; //initial value
    [SerializeField] private Transform locationToCombine;
    public Vector2 blueGuyPos;
    public GameObject mainGuy;
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
        blueGuyPos = GameManager.instance.redGuy.transform.position;
        if (Input.GetKeyDown(KeyCode.E) && (Vector2.Distance(transform.position, blueGuyPos) < combineDistance)) //combine //check for distance between this gameobject and redguy gameobject
        {
            print("combine");
            OnCombine();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && !GameManager.instance.blueGuy.enabled)
        {
            GameManager.instance.blueGuy.enabled = true;
            GameManager.instance.blueGuy.arrowSprite.SetActive(true);
            this.arrowSprite.SetActive(false);
            rb.velocity = Vector2.zero;
            this.enabled = false;
        }


    }
    void OnCombine()
    {
        Vector2 spawnDistance;
        spawnDistance.x = transform.position.x + (blueGuyPos.x - transform.position.x) / 2;  //finding midpoint between 2 distances // not sure if this is right
        spawnDistance.y = transform.position.y + (blueGuyPos.y - transform.position.y) / 2;
        locationToCombine.position = new Vector2(spawnDistance.x, spawnDistance.y);
        Instantiate(mainGuy, locationToCombine.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(GameManager.instance.blueGuy.gameObject);
        //destroy this and red guy after
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
