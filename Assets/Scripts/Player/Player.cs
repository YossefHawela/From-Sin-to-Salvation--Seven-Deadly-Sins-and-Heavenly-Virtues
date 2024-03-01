using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    // components
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anime;


    // inputs
    [SerializeField] private InputActionReference act;

    // movement
    [SerializeField] private float speed = 0f;
    private float movementX;
    private float movementY;

    // animation
    private enum State { idle, walk }
    private State state = State.idle;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        SetState();
        anime.SetInteger("State", (int)state);
    }


    // movement input
    private void OnMove(InputValue MV)
    {
        Vector2 move = MV.Get<Vector2>();

        movementX = move.x;
        movementY = move.y;
    }


    // movement controll
    void Movement()
    {
        Vector2 movement = new Vector2(movementX, movementY);

        if (movementX == -1)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        if (movementX == 1)
        {
            transform.localScale = new Vector2(1f, 1f);

        }
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(movement.x * speed, movement.y * speed), 0.1f);
    }

    // animation states
    private void SetState()
    {
        if (Mathf.Abs(movementX) > Mathf.Epsilon)
        {
            state = State.walk;
        }
        else
        {
            state = State.idle;
        }
    }
}
