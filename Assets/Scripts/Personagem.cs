using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;
    private bool viradoParaDireita;
    private Animator anime;
    private bool ataque;
    private bool estaNoChao;
    public float alturaPulo = 250f;
    public GameObject menssagem;
    // Start is called before the first frame update
    void Start()
    {
        viradoParaDireita = true;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        estaNoChao = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        movimentacao(horizontal);
        virar(horizontal);
        atacar();
        resetaAtaque();
        //pular();
    }

    private void Update()
    {
        teclando();
        pulo();
    }

    void movimentacao(float horizontal)
    {
        if (!this.anime.GetCurrentAnimatorStateInfo(0).IsTag("Atacando"))
        {
            /*if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-40f * Time.deltaTime * velocidade, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(40f * Time.deltaTime * velocidade, rb.velocity.y);
            }*/

            rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);

            //Debug.Log(rb.velocity);
            if (Mathf.Abs(rb.velocity.x) > 0.010f)
            {
                anime.SetBool("andando", true);
            }
            else
            {
                anime.SetBool("andando", false);
            }
        }
        
        //anime.SetFloat("velocidade", Mathf.Abs(horizontal));
    }

    void virar(float horizontal)
    {
        if(horizontal > 0 && !viradoParaDireita || horizontal < 0 && viradoParaDireita)
        {
            viradoParaDireita = !viradoParaDireita;
            Vector3 tamanhoPersonagem = transform.localScale;
            tamanhoPersonagem.x *= -1;
            transform.localScale = tamanhoPersonagem;
        }

    }

    void atacar()
    {
        if (ataque && !this.anime.GetCurrentAnimatorStateInfo(0).IsTag("Atacando"))
        {
            anime.SetTrigger("atacando");
            rb.velocity = Vector2.zero;
        }
    }

    void teclando()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ataque = true;
        }
    }

    void resetaAtaque()
    {
        ataque = false;
    }

    void pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaNoChao)
            {
                rb.AddForce(new Vector2(0f, alturaPulo), ForceMode2D.Impulse);
                anime.SetTrigger("saltando");
            }
            
        }
    }


    void OnCollisionStay2D(Collision2D obj)
    {
        estaNoChao = true;
    }

    private void OnCollisionExit2D(Collision2D obj)
    {
        if (estaNoChao)
        {
            estaNoChao = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "memoria_ram")
        {
            Destroy(collision.gameObject);
            menssagem.SetActive(true);
        }

        if (collision.gameObject.tag == "obstaculo")
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstaculo")
        {
            SceneManager.LoadScene("gameOver");
        }
    }*/


    /*
    void OnCollisionExit2D(Collision2D obj)
    {
        noChao = false;
    }

    void pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.AddForce(Vector2.up * alturaPulo);
            anime.SetTrigger("saltando");
        }
    }*/
}
