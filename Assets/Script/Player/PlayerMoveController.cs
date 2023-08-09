using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMoveController : MonoBehaviour
{//của Player
    private float move;
    private float horizontalmove;
    private float updown;
    public float speed;
    public float jumpForce;

    //private GatherInput gI;
    private Rigidbody2D rb;
    private Animator anim;

    private int direction = 1;
    private bool doubleJump = true;//k cần dùng vì có additionalJump
    //public int additionalJumps = 1;//số lần nhảy trên không
    private int resetJumpsNumber;

    public float rayLength;//Độ cao so với đất
    public LayerMask groundLayer;
    public Transform leftPoint;
    public Transform rightPoint;
    private bool grounded = true;

    public bool knockBack = false;//bị đẩy trở lại khi bị thương
    public bool hasControl = true;

    public bool onLadders;
    public float climbSpeed;
    public float climbHorizontalSpeed;
    private float startGravity;

    public GameObject NameText;

    // Start is called before the first frame update
    void Start()
    {
        //gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startGravity = rb.gravityScale;

        //resetJumpsNumber = additionalJumps; 
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorvalues();
    }

    private void FixedUpdate()
    {
        CheckStatus();
        if (knockBack||hasControl==false)
            return;//kiểu nếu bị bật lại thì trả về luôn k gọi mấy hàm dưới move jump dưới nữa

        Move();

        Jump();

        horizontalmove = Input.GetAxis("Horizontal");
        if(Input.GetAxis("Horizontal")>0|| Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector2(speed * horizontalmove, rb.velocity.y);
        }
        Flip();

        //Dùng để di chuyển và flip luôn(có vẻ ngắn)
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //    rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        //}
        //else if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transform.localScale = new Vector3(-1, 1, 1);
        //    rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        //}


    }

    private void Move()
    {
        Flip();
        float move = CrossPlatformInputManager.GetAxis("Horizontal");
        float updown = CrossPlatformInputManager.GetAxis("Vertical");
        //rb.velocity = new Vector2(speed * gI.valueX, rb.velocity.y);//di chuyển pc
        rb.velocity = new Vector2(speed * move, rb.velocity.y);//mobile
        if (onLadders)
        {
            rb.gravityScale = 0;//trọng lực=0
            //rb.velocity = new Vector2(climbHorizontalSpeed * gI.valueX, climbSpeed * gI.valueY);//leo thang pc
            rb.velocity = new Vector2(climbHorizontalSpeed * move, climbSpeed * updown );//leo thang mobile, có thể sang ngang
            if (rb.velocity.y == 0)
                anim.enabled = false;
            else
                anim.enabled = true;
        }
    }
    //ExitLadder();
    //ExitLadder();
    //rb.velocity = new Vector2(gI.valueX * speed, jumpForce);//Nhảy trên pc
    //rb.velocity = new Vector2(gI.valueX * speed, jumpForce);
    public void ExitLadder()//thoát khỏi thang
    {
        rb.gravityScale = startGravity;//trọng lực trở về bình thường
        onLadders = false;
        anim.enabled = true;
    }

    private void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (grounded||onLadders)
            {
                
                rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed, jumpForce);//nhảy trên mobile
                //rb.AddForce(transform.up * jumpForce);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed, jumpForce);
                doubleJump = false;
                //additionalJumps -= 1;
            }
            
        }
        else if (Input.GetButtonDown("Jump"))
        {
            if (grounded || onLadders)
            {
                ExitLadder();
                //rb.velocity = new Vector2(gI.valueX * speed, jumpForce);//Nhảy trên pc
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, jumpForce);//nhảy trên mobile
                doubleJump = true;
            }
            else if (/*additionalJumps > 0*/doubleJump)
            {
                ExitLadder();
                //rb.velocity = new Vector2(gI.valueX * speed, jumpForce);
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, jumpForce);
                doubleJump = false;
                //additionalJumps -= 1;
            }
        }
        //gI.jumpInput = false;
    }

    private void CheckStatus()//kiểm tra trạng thái
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, groundLayer);
        RaycastHit2D rightCheckHit = Physics2D.Raycast(rightPoint.position, Vector2.down, rayLength, groundLayer);
        if (leftCheckHit||rightCheckHit)
        {
            grounded = true;
            doubleJump = false;
            //additionalJumps = resetJumpsNumber;
        }
        else
        {
            grounded = false;
        }
        SeeRays(leftCheckHit, rightCheckHit);//chưa biết dùng như nào , chắc chỉ vẽ đường kẻ để nhận biết ở chân 
    }

    private void Flip()
    {
        if (/*gI.valueX * direction < 0 ||*/Input.GetAxis("Horizontal")*direction<0 || CrossPlatformInputManager.GetAxis("Horizontal") * direction<0)
        {
            transform.Rotate(0f, 180f, 0f);
            //transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;//đầu tiên quay sang trái thì direction sẽ =-1,khi đó ấn sang trái thì gI.valueX vẫn là >0 nhưng khi ấn sang phải thì sẽ<0 và sẽ thực hiện lại hàm này
            NameText.transform.localScale = new Vector2(direction,1) ;
        }
    }

    private void SeeRays(RaycastHit2D leftCheckHit,RaycastHit2D rightCheckHit)//chưa rõ , k có cũng đc
    {
        Color color1 = leftCheckHit ? Color.red : Color.green;
        Color color2 = rightCheckHit ? Color.red : Color.green;

        Debug.DrawRay(leftPoint.position, Vector2.down * rayLength, color1);
        Debug.DrawRay(rightPoint.position, Vector2.down * rayLength, color2);
    }

    private void SetAnimatorvalues()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));//Abs tri tuyet doi
        anim.SetFloat("vspeed", rb.velocity.y);
        anim.SetBool("grounded", grounded);
        anim.SetBool("Climb", onLadders);//onLadder có giá trị true false tùy vào chương trình
    }

    public IEnumerator KnockBack(float forceX, float forceY, float duration, Transform otherObject)
    {
        int knockBackDirection;
        if (transform.position.x < otherObject.position.x)
        {
            knockBackDirection = -1;
        }
        else
        {
            knockBackDirection = 1;
        }
        knockBack = true;
        rb.velocity = Vector2.zero;
        Vector2 theForce = new Vector2(knockBackDirection * forceX, forceY);
        rb.AddForce(theForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        knockBack = false;
        rb.velocity = Vector2.zero;
    }
}
