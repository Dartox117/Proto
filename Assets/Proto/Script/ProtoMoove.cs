using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ProtoMoove : MonoBehaviour
{
    //Speed of movement
    [SerializeField] float mouvementSpeed = 8f;
    [SerializeField] float NormalSpeed = 8f;
    [SerializeField] float IcemouvementSpeed = 10f;
    //Set of the isgrounded bool
    [SerializeField] bool IsGrounded;
    private int GoRight = 0;
    private Rigidbody2D rb;
    // Jump variable
    [SerializeField] float fallGravityScale = 10f;
    [SerializeField] float gravityScale = 1f;
    [SerializeField] float JumpPower = 4f;
    public int Shooes = 1;
    //Used to change the sprite color to match platform color
    [SerializeField] SpriteRenderer SpriteRenderer;
    private Color Plat1 = new Color32(0xB7,0x43,0x42,0xFF);
    private Color Plat2 = new Color32(33, 144, 1, 255);
    private Color Plat3 = new Color32(0, 0, 255, 255);
    private Color Plat4 = new Color32(255, 255, 0, 255);
    [SerializeField] GameObject Bounce;
    // Start is called before the first frame update
    void Start()
    {
        {
            //Get Rigibody to the component
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoove();
        PlayerJump();
        ShooesChange();
    }

    private void PlayerMoove()
    {
        //When press player goes left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SpriteRenderer.flipX = true;
            if (Shooes == 3 && IsGrounded)
            {
                mouvementSpeed = IcemouvementSpeed;
                transform.Translate(-mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
                GoRight = 2;
            }
            else
            {
                mouvementSpeed = NormalSpeed;
                transform.Translate(-mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
            }
            
        }
        //When press player goes right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SpriteRenderer.flipX = false;
            if (Shooes == 3 && IsGrounded)
            {
                mouvementSpeed = IcemouvementSpeed;
                transform.Translate(mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
                GoRight = 1;
            }
            else
            {
                mouvementSpeed = NormalSpeed;
                transform.Translate(mouvementSpeed * Time.deltaTime, 0, 0, Space.World);
                
            }
        }
        if (IsGrounded && Shooes == 3)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
            }
        }
    }

    private void PlayerJump()
    {
        //Check of bool
        if (IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(iceJump());
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
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Shooes = 1;
                SpriteRenderer.color = Plat1;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                Shooes = 2;
                SpriteRenderer.color = Plat2;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                Shooes = 3;
                SpriteRenderer.color = Plat3;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                Shooes = 4;
                SpriteRenderer.color = Plat4;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //If player touch a plateform change is grounded bool
        if ((other.gameObject.CompareTag("PlateformA"))|| (other.gameObject.CompareTag("PlateformB")) || (other.gameObject.CompareTag("PlateformC")))
        {
            IsGrounded = true;
        }
        //Defeat condition on Plateform A
        if (other.gameObject.CompareTag("PlateformA") && Shooes!=1)
        {
            Debug.Log("Perdu Rouge");
            //Shooes = 1;
            //SpriteRenderer.color = Plat1;
        }
        //Defeat condition on Plateform B
        if (other.gameObject.CompareTag("PlateformB") && Shooes != 2)
        {
            Debug.Log("Perdu Vert");
            //Shooes = 2;
           // SpriteRenderer.color = Plat2;
        }
        //Defeat condition on Plateform C
        if (other.gameObject.CompareTag("PlateformC") && Shooes != 3)
        {
            Debug.Log("Perdu Bleu");
            //Shooes = 3;
            //SpriteRenderer.color = Plat3;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        //Change bool if player leave ground
        if ((other.gameObject.CompareTag("PlateformA")) || (other.gameObject.CompareTag("PlateformB")) || (other.gameObject.CompareTag("PlateformC")))
        {
            IsGrounded = false;
        }
    }
    private IEnumerator iceJump()
    {
        yield return new WaitForSeconds(1f);
        mouvementSpeed = NormalSpeed;
    }


}
