using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpForce;
    public float jumpThereshold;
    public float runForce;
    public float runSpeed;
    public float runThereshold;
    public float AttackSpeed;
    public float EnemyAttack;
   
    public float timelimit;
    public float timeLowerLimit;
    public float invisibleInterval;

    public int Hp;

    public GameObject Umbrella;
    

    [SerializeField]
    bool isGround;
    [SerializeField]
    bool isJump = true;
    [SerializeField]
    bool isFall;
    [SerializeField]
    bool isDash;
    [SerializeField]
    bool isUmbrella;
    [SerializeField]
    bool isCoolTime;
    [SerializeField]
    bool isRain;

    public bool isKnockBack;

    int key = 0;
    [SerializeField]
    float time = 0;
    float invisibleTimer = 0;

    string state;
    string preveState;
    string LRState;
    float stateEffect = 1;

    private Rigidbody2D rb2d;

    private Animator animator;

    private new SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        Hp = 12;

        Umbrella.SetActive(false);
        LRState = "RIGHT";
	}
	
	// Update is called once per frame
	void Update () {
        GetInputKey();
        ChangeState();
        //ChangeAnimation();

        if (!isKnockBack)
        {
            Move();
        }
        
        KnockBack();

        if(isRain==true && !isUmbrella)
        {
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if ((!isKnockBack))
        {
            
            
                //左右移動
                transform.position += new Vector3(runSpeed * Time.deltaTime * key * stateEffect, 0, 0);
            

            Attack();
        }
    }

    void GetInputKey()
    {
        key = 0;
        if ((!isDash) && (!isKnockBack))
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                key = 1;
                LRState = "RIGHT";
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                key = -1;
                LRState = "LEFT";
            }
        }
        
    }

    void ChangeState()
    {
        if (Mathf.Abs(rb2d.velocity.y) > jumpThereshold)
        {
            isGround = false;
        }

        if ((Mathf.Abs(rb2d.velocity.x) > runThereshold) && (isGround)) 
        {
            isDash = true;
        }
        else isDash = false;


        if (isGround == true)
        {
            if (key != 0)
            {
                state = "RUN";
            }
            else
            {
                state = "IDLE";
            }
        }
        else
        {
            if (rb2d.velocity.y > 0)
            {
                state = "JUMP";
                isFall = false;
            }
            else if (rb2d.velocity.y < 0)
            {
                state = "FALL";
                isFall = true;
            }
        }

        if (isUmbrella)
        {
            state = "ATTACK";
        }
        if (isKnockBack)
        {
            state = "KNOCKBACK";
        }
    }

    void Move()
    {
        if (isGround)
        {
            //ジャンプ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * jumpForce);
                isGround = false;
            }
            
        }
        //else if(isJump)
        //{
        //    //二段ジャンプ
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        rb2d.velocity = Vector2.zero;
        //        rb2d.AddForce(Vector2.up * jumpForce);
        //        isJump = false;
        //    }
        //}

        if (!isFall)
        {
            //ジャンプ強さ
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb2d.velocity = Vector2.zero;
            }
        }
        if (isFall && isUmbrella)
        {
            if (time <= 3) { rb2d.velocity = Vector2.zero; }
            if (time > 3 && time <= 7) { rb2d.velocity = new Vector2(0, -0.5f); }
            if (time > 7) { rb2d.velocity = new Vector2(0, -1); }
        }
        
        //float speedX = Mathf.Abs(rb2d.velocity.x);
      
    }

    void Attack()
    {
        //傘をさす
        if (Input.GetKey(KeyCode.Q) && !isUmbrella && !isCoolTime) 
        {
            Umbrella.SetActive(true);
            isUmbrella = true;
        }
        

        //
        if (Input.GetKeyUp(KeyCode.Q) && isUmbrella)
        {
            //Umbrella.SetActive(false);
            isUmbrella = false;
           
        }

        if (isUmbrella)
        {
            time += Time.deltaTime;

            

            //後隙
            if (time >= timelimit)
            {
                isUmbrella = false;
                isCoolTime = true;
            }
        }

        if (!isUmbrella)
        {
            Umbrella.SetActive(false);
            time -= Time.deltaTime;
            if (time < timeLowerLimit)
            {
                time = timeLowerLimit;
                isCoolTime = false;
            }
        }
    }

    void KnockBack()
    {
        if (isKnockBack)
        {
            invisibleTimer += Time.deltaTime;
            if (invisibleTimer > invisibleInterval)
            {
                invisibleTimer = 0;
                rb2d.AddForce(Vector2.zero);
                isKnockBack = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround) { isGround = true; }
            if (!isJump) { isJump = true; }
            if (isFall) { isFall = false; }
        }
        if (col.gameObject.tag == "SafeZone")
        {
            isRain = false;
        }

        if ((col.gameObject.tag == "Enemy") && (!isKnockBack))
        {
            isKnockBack = true;
            Hp -= 1;

            Vector3 knockBackDirection = (col.gameObject.transform.position - transform.position).normalized;

            knockBackDirection.x *= -1;
            knockBackDirection.y = 1;
            knockBackDirection.z += -1;

            rb2d.AddForce(Vector2.zero);
            rb2d.AddForce(knockBackDirection* EnemyAttack);
        }
        //if ((col.gameObject.tag == "Enemy") && (isUmbrella) && (isAttack2)) 
        //{
        //    rb2d.velocity = Vector2.zero;
        //    rb2d.AddForce(Vector2.up * jumpForce);
        //    isJump = true;
        //}

        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (!isGround) { isGround = true; }
            if (!isJump) { isJump = true; }
            if (isFall) { isFall = false; }
        }
        if (col.gameObject.tag == "SafeZone")
        {
            isRain = false;
        }


    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "SafeZone")
        {
            
            isRain = true;
        }
    }

    private void ChangeAnimation()
    {
        
        if (LRState == "RIGHT")
        {
            renderer.flipX = false;
        }
        else if (LRState == "LEFT") 
        {
            renderer.flipX = true;
        }

        if (preveState != state)
        {
            switch (state)
            {
                case "RUN":
                    animator.SetBool("isRun", true);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isIdle", false);
                    stateEffect = 1f;
                    break;
                case "JUMP":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isJump", true);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isIdle", false);
                    stateEffect = 1f;
                    break;
                case "ATTACK":
                    animator.SetBool("isRun", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isAttack", true);
                    animator.SetBool("isIdle", false);
                    stateEffect = 0.5f;
                    break;
                default:
                    animator.SetBool("isRun", false);
                    animator.SetBool("isJump", false);
                    animator.SetBool("isAttack", false);
                    animator.SetBool("isIdle", true);
                    stateEffect = 1f;
                    break;
            }

            preveState = state;
        }
    }
}
