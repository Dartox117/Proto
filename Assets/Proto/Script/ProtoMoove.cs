using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
using Cinemachine;

public class ProtoMoove : MonoBehaviour
{
    public GameObject[] BrokenIce;
    private Vector3 RespawnPoint;

    [Header("Shooes")]
    [SerializeField] float mouvementSpeed = 10f;
    [SerializeField] float NormalSpeed = 10f;
    [SerializeField] float IcemouvementSpeed = 13f;



    public bool IceActive = false;
    public bool MontActive = false;
    public bool DestroyActive = false;
    public bool IsIntro;


    private Rigidbody2D rb;
    float HorizontalInput = 0f;

    [Header("Jump")]
    // Jump variable
    [SerializeField] float fallGravityScale = 1f;
    [SerializeField] float gravityScale = 3f;
    [SerializeField] float JumpPower = 10f;
    [SerializeField] float BounceForce = 15f;

    public int Shooes = 2;
    public float Damage = 0.1f;
    public float TutoDamage = 0.05f;
    public float ActualDamage;

    public bool CanMoove = true;
    public bool IsTuto;
    

    [SerializeField] Animator animator;

    [Header("Sprite")]
    //Used to change the sprite color to match platform color
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite Base;
    [SerializeField] Sprite Glisse;
    [SerializeField] Sprite Mont;
    [SerializeField] Sprite Pic;


    private Color Plat3 = new Color32(0, 0, 255, 255);
    private Color BaseColor = new Color32(255, 255, 255, 255);


    public GameObject DefeatMenu;
    public GameObject PauseMenu;

    [Header("UI")]
    //UI GameObject
    public GameObject ImageTouche;
    [SerializeField] Image imageTouche;
    [SerializeField] Sprite NormalTouche;
    [SerializeField] Sprite NeigeTouche;
    [SerializeField] Sprite PatinsTouche;
    [SerializeField] Sprite PicTouche;
    [SerializeField] Image image;
    [SerializeField] Sprite NormalUI;
    [SerializeField] Sprite NeigeUI;
    [SerializeField] Sprite PatinsUI;
    [SerializeField] Sprite PicUI;

    [Header("IsGrounded")]
    [SerializeField] Transform OverlapPoint;
    [SerializeField] Transform OverlapPoint2;
    [SerializeField] LayerMask Ground;
    //Set of the isgrounded bool
    [SerializeField] bool IsGrounded;

    private float Shooes1;
    [Header("Particle")]
    [SerializeField] ParticleSystem SnowStep;
    [SerializeField] ParticleSystem IceStep;
    public ParticleSystem ActualStep;

    [Header("Sound")]
    [SerializeField] AudioSource SnowStepSound;
    [SerializeField] AudioSource IceStepSound;
    public AudioSource ActualStepSound;
    [SerializeField] AudioSource SnowJump;
    [SerializeField] AudioSource IceJump;
    private AudioSource ActualJump;
    [SerializeField] AudioSource DamageSound;
    [SerializeField] AudioSource Music;

    [Header("Code")]
    //Imported code 
    [SerializeField] HealthBar healthBar;
    [SerializeField] MontShooes montShooes;
    [SerializeField] DestroyShooes destroyShooes;
    [SerializeField] IceShooes iceShooes;
    [SerializeField] DefeatMenu defeatMenu;

    [Header("GameObject")]
    [SerializeField] GameObject FakePlateform;



    // Start is called before the first frame update
    void Start()
    {
    
        defeatMenu.CanPause = true;
      //Get Rigibody to the component
      rb = GetComponent<Rigidbody2D>();
        ActualDamage = TutoDamage;
        ActualStep = SnowStep;
        CanMoove = false;
        IsTuto = true;
        IsIntro = true;
        ActualStepSound = SnowStepSound;
        ActualJump = SnowJump;
      


    }

    // Update is called once per frame
    void Update()
    {
        if (defeatMenu.CanPause)
        {
            defeatMenu.Pause();
        }
        if (CanMoove)
        {
            PlayerMoove();
            PlayerJump();
            ShooesChange();
            Grounded();
            SnowStepPlay();
        }
    }
    

    private void PlayerMoove()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        //When press player goes left

        if (HorizontalInput < 0)
        {
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = true;
            transform.Translate(-mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
            //rb.velocity = new Vector2(HorizontalInput * mouvementSpeed, rb.velocity.y);
        }
        //When press player goes right
        else if (HorizontalInput > 0)
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
        if (IsGrounded && Shooes == 3)
        {
            if (Input.GetButtonUp("Horizontal"))
            {
                if (spriteRenderer.flipX)
                {
                    rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
                }
                
            }
        }
    }

    private void PlayerJump()
    {
        //Check of bool
        if (IsGrounded)
        {
            if (Input.GetButton("CustomJump"))
            {
                animator.SetBool("IsJump", true);
                ActualJump.Play();
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
            if ((Shooes1 !=0||Input.GetButton("Shooes1BIS")) && MontActive)
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
            else if ((Input.GetAxis("Shooes4")!=0 || Input.GetButton("Shooes4BIS")) && DestroyActive)
            {
                animator.SetInteger("Shooes", 4);
                Shooes = 4;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Pic;
                image.sprite = PicUI;
                imageTouche.sprite = PicTouche;
            }
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Defeat condition on Plateform A
        if (other.gameObject.CompareTag("PlateformA") && Shooes!=1)
        {
            MontShooesChange();
            StartCoroutine(damage());


        }
        //Defeat condition on Plateform B
        if (other.gameObject.CompareTag("PlateformB") && Shooes != 2)
        {
            BaseShooesChange();
            StartCoroutine(damage());

            
        }
        //Defeat condition on Plateform C
        if (other.gameObject.CompareTag("PlateformC") && Shooes != 3)
        {
            IceShooesChange();
            StartCoroutine(damage());

        }
        else if (other.gameObject.CompareTag("PlateformC"))
        {
            mouvementSpeed = IcemouvementSpeed;
        }
        if (other.gameObject.CompareTag("PlatformD") && Shooes != 4)
        {
            StartCoroutine(damage());
        }
        else if (other.gameObject.CompareTag("PlatformD"))
        {
            rb.AddForce(Vector2.up * BounceForce, ForceMode2D.Impulse);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(damage());
            defeatMenu.Death();
            DefeatMenu.SetActive(true);
        }
        if (other.gameObject.CompareTag("Fake"))
        {
            FakePlateform.SetActive(false);
        }
        
    }
    void Grounded()
    {
        IsGrounded = Physics2D.OverlapArea(OverlapPoint.position, OverlapPoint2.position, Ground);
        if (IsGrounded )
        {

            animator.SetBool("IsJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        ////Change bool if player leave ground
        if ((other.gameObject.CompareTag("PlateformA")) || (other.gameObject.CompareTag("PlateformB")) || (other.gameObject.CompareTag("PlateformC"))|| (other.gameObject.CompareTag("PlatformD")))
        {
            IsGrounded = false;
            animator.SetBool("IsJump", true);
        }
        if (other.gameObject.CompareTag("PlateformC"))
        {
            mouvementSpeed = NormalSpeed;
        }
        if (other.gameObject.CompareTag("Cinematique"))
        {
            ActualStep.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            RespawnPoint = transform.position;
            CanMoove = true;

        }
        if (other.gameObject.CompareTag("ENDLVL1"))
        {
            BaseShooesChange();
            CanMoove = false;
            healthBar.ActualFreezeSpeed = 0;
        }
    }
    private IEnumerator damage()
    {
        healthBar.Bar.fillAmount += ActualDamage;
        spriteRenderer.color = Plat3;
        DamageSound.Play();
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = BaseColor;
        ActualStep.Pause();
        ActualStep.Clear();
    }
    private void IceShooesChange()
    {
        animator.SetInteger("Shooes", 3);
        Shooes = 3;
        JumpPower = 10f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Glisse;
        image.sprite = PatinsUI;
        imageTouche.sprite = PatinsTouche;
        ActualStep.Pause();
        ActualStep.Clear();
        ActualStep = IceStep;
        ActualJump = IceJump;
        ActualStepSound.Stop();
        ActualStepSound = IceStepSound;
    }
    private void MontShooesChange()
    {
        animator.SetInteger("Shooes", 1);
        Shooes = 1;
        JumpPower = 13f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Mont;
        image.sprite = NeigeUI;
        imageTouche.sprite = NeigeTouche;
        ActualStep.Pause();
        ActualStep.Clear();
        ActualStep = SnowStep;
        ActualJump = SnowJump;
        ActualStepSound.Stop();
        ActualStepSound = SnowStepSound;
    }
    private void BaseShooesChange()
    {
        animator.SetInteger("Shooes", 2);
        Shooes = 2;
        JumpPower = 10f;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Base;
        image.sprite = NormalUI;
        imageTouche.sprite = NormalTouche;
        ActualStep.Pause();
        ActualStep.Clear();
        ActualStep = SnowStep;
        ActualJump = SnowJump;
        ActualStepSound.Stop();
        ActualStepSound = SnowStepSound;
    }

    private void SnowStepPlay()
    {
        if (IsGrounded && HorizontalInput != 0)
        {
            ActualStep.Play();
            ActualStepSound.enabled = true;
        }
        else
        {
            ActualStep.Pause();
            ActualStep.Clear();
            ActualStepSound.enabled=false;
        }
        
    }

    public IEnumerator Respawn()
    {
        BaseShooesChange();
        transform.position = RespawnPoint;
        healthBar.Bar.fillAmount = 0f;  
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(0.7f);
        CanMoove = true;
        spriteRenderer.flipX = false;
        DefeatMenu.SetActive(false);
        BrokenIceRespawn();
        if (IsTuto)
        {
            Debug.Log("TUTO");
            MontActive = false;
            IceActive = false;
            DestroyActive = false;
            montShooes.self.SetActive(true);
            iceShooes.self.SetActive(true);
            destroyShooes.self.SetActive(true);
        }

    }
    private void BrokenIceRespawn()
    {
        foreach (GameObject broken in BrokenIce)
        {
            broken.SetActive(true);
        }
    }

    public void CanMooveSignal()
    {
        Music.Play();
        CanMoove = true;
        IsIntro = false;
        RespawnPoint = transform.position;
        healthBar.Bar.fillAmount = 0f;
        healthBar.FreezeSpeed = healthBar.ActualFreezeSpeed;
    }
    







}
