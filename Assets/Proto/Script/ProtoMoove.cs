using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using Cinemachine;

public class ProtoMoove : MonoBehaviour
{
    //Speed of movement
    [SerializeField] float mouvementSpeed = 10f;
    [SerializeField] float NormalSpeed = 10f;
    [SerializeField] float IcemouvementSpeed = 13f;
    //Set of the isgrounded bool
    [SerializeField] bool IsGrounded;
    public bool IceActive = false;
    public bool MontActive = false;
    public bool DestroyActive = false;
    private int GoRight = 0;
    private Rigidbody2D rb;
    float HorizontalInput = 0f;
    // Jump variable
    [SerializeField] float fallGravityScale = 1f;
    [SerializeField] float gravityScale = 3f;
    [SerializeField] float JumpPower = 10f;
    public int Shooes = 2;
    

    [SerializeField] Animator animator;


    //Used to change the sprite color to match platform color
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite Base;
    [SerializeField] Sprite Glisse;
    [SerializeField] Sprite Mont;
    [SerializeField] Sprite Pic;


    private Color Plat3 = new Color32(0, 0, 255, 255);
    private Color BaseColor = new Color32(255, 255, 255, 255);


    [SerializeField] GameObject DefeatMenu;
    [SerializeField] GameObject Tuto;

    //UI GameObject
    [SerializeField] Image image;
    [SerializeField] Sprite NormalUI;
    [SerializeField] Sprite NeigeUI;
    [SerializeField] Sprite PatinsUI;
    [SerializeField] Sprite PicUI;

    [SerializeField] Transform OverlapPoint;
    [SerializeField] Transform OverlapPoint2;
    [SerializeField] LayerMask Ground;

    private float Shooes1;


    //Imported code 
    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
    
      //Get Rigibody to the component
      rb = GetComponent<Rigidbody2D>();
      


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoove();
        PlayerJump();
        ShooesChange();
        Grounded();
    }
    

    private void PlayerMoove()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        //When press player goes left

        if (HorizontalInput<0)
        {
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = true;
            transform.Translate(-mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
            //rb.velocity = new Vector2(HorizontalInput * mouvementSpeed, rb.velocity.y);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        //When press player goes right
        if (HorizontalInput > 0)
        {
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = false;
            transform.Translate(mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
            //rb.velocity = new Vector2(HorizontalInput * mouvementSpeed, rb.velocity.y);


        }
        else
        {
            animator.SetBool("Walk", false);
        }
        //if (IsGrounded && Shooes == 3)
        //{
            
        //        if (AxisState.)
        //    {
        //        rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
        //    }
            
                
            
        //        if (Input.GetKeyUp(KeyCode.D))
        //        {
        //            rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
        //        }
            
                
        //}
    }

    private void PlayerJump()
    {
        //Check of bool
        if (IsGrounded)
        {
            if (Input.GetButton("CustomJump"))
            {
                rb.velocity = Vector2.zero;
                //Add force to player to make it jump
                
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                
                 if (rb.velocity.y > 0)
                {
                    rb.gravityScale = gravityScale;
                }
                else
                {
                    rb.gravityScale = fallGravityScale;
                }

            }
        }
     }
    // Check is grounded, change shooes and color of the player
    private void ShooesChange()
    {
        if(!IsGrounded)
        {
            Shooes1 = Input.GetAxis("Shooes1");
            if (Shooes1 !=0 && MontActive)
            {
                MontShooesChange();
            }
            else if (Input.GetButton("Shooes2"))
            {
                BaseShooesChange();

            }
            else if (Input.GetButton("Shooes3")&&IceActive)
            {
                IceShooesChange();
            }
            else if (Input.GetAxis("Shooes4")!=0 &&DestroyActive)
            {
                Shooes = 4;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Pic;
                image.sprite = PicUI;
            }
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Defeat condition on Plateform A
        if (other.gameObject.CompareTag("PlateformA") && Shooes!=1)
        {
            Debug.Log("Perdu Rouge");
            StartCoroutine(damage());
            MontShooesChange();

        }
        //Defeat condition on Plateform B
        if (other.gameObject.CompareTag("PlateformB") && Shooes != 2)
        {
            Debug.Log("Perdu Vert");
            StartCoroutine(damage());
            BaseShooesChange();
            
        }
        //Defeat condition on Plateform C
        if (other.gameObject.CompareTag("PlateformC") && Shooes != 3)
        {
            Debug.Log("Perdu Bleu");
            StartCoroutine(damage());
            IceShooesChange();
        }
        else if (other.gameObject.CompareTag("PlateformC"))
        {
            mouvementSpeed = IcemouvementSpeed;
        }
        if (other.gameObject.CompareTag("PlatformD") && Shooes != 4)
        {
            Debug.Log("Perdu glace brisée");
            StartCoroutine(damage());
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(damage());
            DefeatMenu.SetActive(true);
        }
        
    }
    void Grounded()
    {
        IsGrounded = Physics2D.OverlapArea(OverlapPoint.position, OverlapPoint2.position, Ground);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Change bool if player leave ground
        if ((other.gameObject.CompareTag("PlateformA")) || (other.gameObject.CompareTag("PlateformB")) || (other.gameObject.CompareTag("PlateformC")))
        {
            IsGrounded = false;
        }
        if (other.gameObject.CompareTag("PlateformC"))
        {
            mouvementSpeed = NormalSpeed;
        }
    }
    private IEnumerator damage()
    {
        healthBar.Bar.fillAmount += 0.1f;
        spriteRenderer.color = Plat3;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = BaseColor;
    }
    private void IceShooesChange()
    {
        animator.SetInteger("Shooes", 3);
        Shooes = 3;
        JumpPower = 10f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Glisse;
        image.sprite = PatinsUI;
    }
    private void MontShooesChange()
    {
        Shooes = 1;
        JumpPower = 13f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Mont;
        image.sprite = NeigeUI;
    }
    private void BaseShooesChange()
    {
        animator.SetInteger("Shooes", 2);
        Shooes = 2;
        JumpPower = 10f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Base;
        image.sprite = NormalUI;
    }





}
