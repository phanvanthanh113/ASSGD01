using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float moveSpeed = 5f; // Tốc độ di chuyển
    public float jumpForce = 10f; // Lực nhảy

    private bool isGrounded = false; // Kiểm tra có đang chạm đất không
    public Transform groundCheck; // Điểm kiểm tra mặt đất
    public LayerMask groundLayer; // Lớp đất để kiểm tra

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Kiểm tra nếu Rigidbody2D bị thiếu
        if (rb == null)
        {
            Debug.LogError("Lỗi: Không tìm thấy Rigidbody2D trên " + gameObject.name);
        }

        // Kiểm tra nếu groundCheck bị thiếu
        if (groundCheck == null)
        {
            Debug.LogError("Lỗi: Chưa gán GroundCheck! Hãy tạo một GameObject nhỏ dưới chân nhân vật và gán vào.");
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Di chuyển nhân vật
        transform.position += new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);

        // Cập nhật animation di chuyển
        animator.SetBool("isWalking", moveInput != 0);

        // Quay mặt nhân vật
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        // Giữ phím Space → Chém liên tục
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        // Kiểm tra nếu groundCheck != null trước khi truy cập
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        else
        {
            Debug.LogError("GroundCheck bị thiếu! Hãy gán nó trong Inspector.");
        }

        // Nhấn phím W hoặc UpArrow để nhảy
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }
}
