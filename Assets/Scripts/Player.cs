using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public Rigidbody2D myBody;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private SpriteRenderer sr;

    private bool isGrounded = true;

    void Awake()
    {
        // these are equivalent to dragging components / objects
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime; // deltaTime sho-aif la zero
        AnimatePlayer();
        PlayerJump();

    }

    void PlayerMoveKeyboard()
    {
        // values: -1, 0, 1
        movementX = Input.GetAxisRaw("Horizontal");
    }

    void AnimatePlayer()
    {
        // right
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }

        //left
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true); // this means: set the "Walk" element to true (see animator)
            sr.flipX = true;
        }
        
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // gets called when player collides with any object
    {
        // if the object we collided in is with the tag "Ground"
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject); // this gameObject is our player
        }
    }
}
