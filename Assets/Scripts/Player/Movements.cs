using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private float horizontal;           //lưu trữ giá trị của trục ngang (horizontal) từ input (mũi tên hoặc A/D).
    private float speed = 4f;           //tốc độ
    private float jumpingPower = 10f;   //lực nhảy
    private float slowdown = 2f;
    private bool isFacingRingt = true;  //xác định hướng nhìn nhân vật

    //khai báo biến private nhưng vẫn có thể chỉnh sửa trên Inspector bằng SerializeField
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Transform headcheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D standingcl;
   
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded())                 //Nếu nhấn space khi trên đất thì nhảy
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);     //velocity là vector tốc độ chuyển động của đối tượng
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)            //Nếu nhấn space khi trên không thì rơi nhanh hơn 
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
        }
        if (Input.GetButtonDown("Crouch") && isGrounded())
        {
            standingcl.enabled = false;
            rb.velocity = new Vector2(horizontal * speed / slowdown, rb.velocity.y);        
        }
        if (Input.GetButtonUp("Crouch") && isGrounded())
        {
            standingcl.enabled = true;
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);   //Nếu nhấn trái phải thì di chuyển
       
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.5f, groundLayer); //Physics2D.OverlapCircle kiểm tra va chạm giữa một hình tròn (có tâm là groundcheck.position)
                                                                                 //với các Collider có thuộc tính lớp (layer) là groundLayer với bán kính 0.2f.
    }

    private void Flip()
    {
        if(isFacingRingt && horizontal < 0f|| !isFacingRingt && horizontal > 0f) //Nếu đang nhìn phải mà bấm sang trái hoặc ngược lại
        {
            isFacingRingt = !isFacingRingt;
            Vector3 localScale = transform.localScale;                           //lấy giá trị hiện tại của nhân vật
            localScale.x *= -1f;                                                 //đảo ngược giá trị vừa lấy
            transform.localScale = localScale;                                   //gán giá trị mới để đảm bảo nv xoay theo chiều ngang
        }
    }

   
}
