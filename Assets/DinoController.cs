using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public Rigidbody2D body;
    public float jumpHeight = 920;
    public Sprite dinoSprite;
    public Sprite dinoDownSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dinoSprite;
        gameObject.GetComponentInChildren<BoxCollider2D>().size = new Vector2(2, 2);
        gameObject.GetComponentInChildren<BoxCollider2D>().offset = new Vector2(1, 1);

        if (Input.GetKeyDown(KeyCode.UpArrow) & IsGrounded()){
            body.AddForce(new Vector2(0, jumpHeight));
        }

        if (Input.GetKey(KeyCode.DownArrow) & IsGrounded()){
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dinoDownSprite;
            gameObject.GetComponentInChildren<BoxCollider2D>().offset = new Vector2(1.5f, 0.66f);
            gameObject.GetComponentInChildren<BoxCollider2D>().size = new Vector2(3f, 1.31f);
        }
    }

    bool IsGrounded(){
        return Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), distance: 0.03f);
    }
}