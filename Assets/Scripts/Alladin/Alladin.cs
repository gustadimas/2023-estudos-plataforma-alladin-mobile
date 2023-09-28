using System;
using UnityEngine;
using UnityEngine.UI;

public class Alladin : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [Space]
    [Header("Arma e Tiro")]
    [SerializeField] float tiroForca;
    [SerializeField] Text txtVida, txtTiros, txtDimas;
    [SerializeField] Sprite[] arma;
    [SerializeField] GameObject tiro;
    [SerializeField] int tirosDisponiveis = 50;
    [SerializeField] float delayEntreTiros = 0.5f;
    float tempoUltimoTiro;
    int index = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ArmaSet();
    }

    void Update()
    {
        TextoVidaAtt();
        TextoTirosAtt();
        TextoDimasAtt();


        if (GameControllerAlladin.vidas <= 0)
        {
            GameObject.FindGameObjectWithTag("ADM").GetComponent<GameControllerAlladin>().Perdeu();
        }

        if (tirosDisponiveis > 0 && Time.time >= tempoUltimoTiro + delayEntreTiros)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                GameObject _tiro = Instantiate(tiro, transform.position + new Vector3(0.5f, 0.18f, 0), Quaternion.identity);
                _tiro.GetComponent<Rigidbody2D>().AddForce(Vector2.right * tiroForca, ForceMode2D.Impulse);
                Destroy(_tiro, 5f);

                tirosDisponiveis--;
                tempoUltimoTiro = Time.time;
            }
        }

        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                float touchDeltaY = _touch.deltaPosition.y;
                rb.velocity = new Vector2(0, touchDeltaY) * moveSpeed;
            }
            else if (_touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vaso"))
        {
            GameControllerAlladin.vidas--;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Maca"))
        {
            tirosDisponiveis++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Dimas"))
        {
            GameControllerAlladin.dimas++;
            Destroy(collision.gameObject);
        }
    }

    void ArmaSet()
    {
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = arma[index];
    }

    void TextoVidaAtt()
    {
        txtVida.text = GameControllerAlladin.vidas.ToString();
    }

    void TextoTirosAtt()
    {
        txtTiros.text = tirosDisponiveis.ToString();
    }

    void TextoDimasAtt()
    {
        txtDimas.text = GameControllerAlladin.dimas.ToString();
    }
}