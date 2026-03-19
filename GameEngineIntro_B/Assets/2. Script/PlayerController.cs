using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// public
    /// </summary>
    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    /// <summary>
    /// private
    /// </summary>
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator myAnimator;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("move", false);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed) // 점프 버튼을 누르면
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput.x > 0) 
        {
                transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (moveInput.magnitude > 0) // moveinput값이 들어왔을경우. 애니메이션 실행
        {
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }

        transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);
    }
}
