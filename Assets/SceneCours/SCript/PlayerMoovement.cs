using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour

//Define speed and bool
{
    [SerializeField] float mouvement_speed = 0.02f;
    [SerializeField] float vitesseInit = 0.02f;
    [SerializeField] Animator Player_Animator;
    bool Player_Run;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject particle;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] float velocity = 10f;
    bool Player_Attack;
    [SerializeField] float dash_speed = 4f;
    [SerializeField] float dash_duration = 1f;
    [SerializeField] float couldown = 10f;
    bool dashUp = true;
    bool IsGrounded;
    private Rigidbody2D rb;
    [SerializeField] float JumpPower = 10f;
    [SerializeField] float fallGravityScale = 0.02f;
    [SerializeField] float gravityScale = 0.02f;
    public bool CanMoove = true;

    //Movement fonction


    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        moovement();
        jump();
        attack();
        if (Input.GetKeyDown(KeyCode.Keypad3) && dashUp && CanMoove)
        {

            Debug.Log("3");

            StartCoroutine(Fonction_Dash());

        }
    }
    private void moovement()
    {
        // Press key to activate the movement
        if (Input.GetKey(KeyCode.LeftArrow) && CanMoove)
        {
            //Go left and acitvate animation and flip the sprite
            go_left();
            Player_Animator.SetBool("BoolRun", true);
            spriteRenderer.flipX = true;
            particle.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && CanMoove)
        {
            //Go Right and acitvate animation and flip the sprite
            go_right();
            Player_Animator.SetBool("BoolRun", true);
            spriteRenderer.flipX = false;


        }
        else
        {
            //stop the Run
            Player_Animator.SetBool("BoolRun", false);

        }

    }
    void go_left()
    {
        transform.Translate(-mouvement_speed, 0, 0, Space.World);
    }

    void go_right()
    {
        transform.Translate(mouvement_speed, 0, 0, Space.World);
    }

    void jump()
    {
            //Jump
            if (IsGrounded == true && CanMoove)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                    if (rb.velocity.y > 0)
                    {
                        rb.gravityScale = gravityScale;
                    }
                    else
                    {
                        rb.gravityScale = fallGravityScale;
                    }

                    //transform.Translate(Vector3.up * JumpPower * Time.deltaTime);
                }
            }
        }
    void attack()
    {
        {
            //Press key 2 to attack
            if (Input.GetKeyDown(KeyCode.Keypad2) && CanMoove)
            {
                Player_Animator.SetBool("BoolAttack", true);
            }
            else
            {
                Player_Animator.SetBool("BoolAttack", false);
            }

        }
    }
    IEnumerator Fonction_Dash()
    {

        dashUp = false;
        Debug.Log("on est la");

        //multiplication de la vitesse
        mouvement_speed = mouvement_speed * dash_speed;

        Debug.Log("Vitesse appliquer");

        // pause/durée
        yield return new WaitForSeconds(dash_duration);

        Debug.Log("pause");

        //Retablisement de la vitesse enregistréeé
        mouvement_speed = vitesseInit;

        //couldown
        yield return new WaitForSeconds(couldown);
        dashUp = true;

        Debug.Log("cooldown");

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
    public void MooveOn()
    {
        CanMoove = true;
    }
}
