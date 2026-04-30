using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// ===| 플레이어 움직임 |===
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// public | ==============================
    /// </summary>
    public float moveSpeed = 7f;
    public float jumpForce = 7f;

    /// <summary>
    /// private | ==============================
    /// </summary>
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator myAnimator;

    float score;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        myAnimator = GetComponent<Animator>(); //애니메이션
        myAnimator.SetBool("move", false);  //애니메이션 초기화

        score = 0f;
    }

    /// <summary>
    /// ===| Input값 받아옴 |===
    /// </summary>
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }


    /// <summary>
    /// ===| 점프 로직 |===
    /// </summary>
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
        MoveScale(); //움직임 코드

        RunAnimator(); //움직임 애니메이션

    }

    /// <summary>
    /// ===| 이동로직 |===
    /// </summary>
    void MoveScale()
    {

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);
    }

    /// <summary>
    /// ===| 애니메이션 로직 |===
    /// </summary>
    void RunAnimator()
    {
        if (moveInput.magnitude > 0) // moveinput값이 들어왔을경우. 애니메이션 실행
        {
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }
    }

    /// <summary>
    /// ===| 충돌처리 (트리거) |===
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Death")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재실행중인 씬을 다시 불러옴
        }
        else
        {
            score += 200;
            HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            SceneManager.LoadScene("PlayScene_" + collision.name); //PlayerScene_에 닿은 트리거콜라이더 오브젝트 이름을 더함.
        }
    }
}
