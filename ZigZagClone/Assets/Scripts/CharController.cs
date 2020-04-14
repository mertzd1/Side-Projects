using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform raystart;

    private Rigidbody rb;
    private bool walkingRight = true;
    private Animator anim;
    private GameManager gameManager;
    public GameObject crystalEffect;
    
    //Use this for initialization of objects
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    //this moves the player forward based on the direction the player is facing (right or left) or 45 or -45
    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("gameStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit hit;
        if(!Physics.Raycast(raystart.position, -transform.up, out hit, Mathf.Infinity)) //the there is a physical substance under the player
        {
            anim.SetTrigger("isFalling");
        }
        if(transform.position.y < -2) //this will end the game after the player falls
        {
            gameManager.EndGame();
        }
    }
    private void Switch()
    {
        if (!gameManager.gameStarted) //the prevents the player from rotating before the game has started
        {
            return;
        }
        walkingRight = !walkingRight;
        if (walkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0); //this changes to the players direction to 45 degrees
        else transform.rotation = Quaternion.Euler(0, -45, 0);
    }
    //this increases the score when a play hits a crystal and then makes the crystal
    //disappear
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            
            gameManager.IncreaseScore();
            //makes the partical effect(crystaleffect) and destroys the object when player hits it
            //the raystart makes it come from the character middle since that is what I set it at
            GameObject g = Instantiate(crystalEffect, raystart.transform.position, Quaternion.identity); 
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
