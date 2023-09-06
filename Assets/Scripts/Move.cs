using UnityEngine;
using System.Collections;

//Simple Script to Move with user input
public class Move : MonoBehaviour 
{
    private CharacterController controller;

    public float speed = 5f;
    private Vector3 gravity = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private float h;
    private float v;

    [SerializeField]
    Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity = Physics.gravity;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        if(controller.enabled) //check for Abilities.cs Event
        {
            if (controller.isGrounded)
            {
                v = Input.GetAxis("Vertical");
                h = Input.GetAxis("Horizontal");
                Vector3 input = new Vector3(h, 0.0f, v);
                velocity = input;

                //Transforms direction from local to world space
                velocity = transform.TransformDirection(velocity);

                velocity *= speed;
            }
            velocity += gravity * dt;

            // Move the controller
            controller.Move(velocity * dt);
        }
        if (animator !=null)
            Animate();
    }

    public void AddVelocity(Vector3 newVelocity)
    {
        velocity += newVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
    public void NullVelocity()
    {
        velocity = new Vector3(0,0,0);
        controller.Move(velocity * Time.deltaTime);
    }
    void Animate()
    {
        float vert = Mathf.Abs(v);
        float hor = Mathf.Abs(h);
        if (vert > hor)
            animator.SetFloat("isMoving", vert);
        else
            animator.SetFloat("isMoving", hor);
    }
}










