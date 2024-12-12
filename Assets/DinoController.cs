using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
    public Rigidbody2D body;
    public float jumpHeight = 920;
    public Sprite dinoSprite;
    public Sprite dinoDownSprite;
    private bool speedUpDown = false;
    public bool gameOver = false;
    [SerializeField] List<EdgeCollider2D> colliders;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver){
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            if (Input.GetKey(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        colliders[0].enabled = true;
        colliders[1].enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dinoSprite;

        if (Input.GetKeyDown(KeyCode.UpArrow) & IsGrounded()){
            body.AddForce(new Vector2(0, jumpHeight));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) & !IsGrounded() & !speedUpDown){
            speedUpDown = true;
            body.velocity = new Vector2(0, 0);
            body.AddForce(new Vector2(0, -jumpHeight/2));
        }

        if (Input.GetKey(KeyCode.DownArrow) & IsGrounded() & !gameOver){
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = dinoDownSprite;
            colliders[0].enabled = false;
            colliders[1].enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.transform.parent.gameObject.CompareTag("Obstacles")){
            gameOver = true;
        }
    }

    bool IsGrounded(){
        if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), distance: 0.03f)){
            speedUpDown = false;
            return true;
        }
        else{
            return false;
        }
    }
}