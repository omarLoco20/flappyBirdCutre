using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class pajaroScript : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    public float velocidadRotacion = 5f;

    private bool haClickeado = false;
    private Rigidbody rb;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI bestCoinText;
    public scriptableScore scoreS;
    public GameObject panelReset;
    int coin;
    int bestCoin;

    void Start()
    {
        coin = 0;
        rb = GetComponent<Rigidbody>();
        bestCoinText.text = "BEST SCORE: " + scoreS.scoreMax;

    }

    void Update()
    {
        // Salta al hacer clic en la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            Saltar();
        }

        // Rota hacia abajo cuando cae
        RotarPajaro();
    }

    void Saltar()
    {
        // Aplica una fuerza hacia arriba al pájaro
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

        // Gira hacia arriba cuando salta
        transform.rotation = Quaternion.Euler(10, 0, 0);

        haClickeado = true;
    }

    void RotarPajaro()
    {
        if (haClickeado)
        {
            // Gira hacia abajo cuando cae
            float anguloRotacion = Mathf.Lerp(45, -45, rb.velocity.y / fuerzaSalto);
            transform.rotation = Quaternion.Euler(anguloRotacion, 0,0 );
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sumarCoin")
        {
            coin++;
            coinText.text = "COINS: " + coin;
        }
        if (other.gameObject.tag == "killPajaro")
        {
            //  SceneManager.LoadScene("SampleScene");
            
            compararScores(coin,bestCoin);
            panelReset.SetActive(true);
        }
    }


    public void compararScores(int coinActual, int mejorScore)
    {
        if (mejorScore < coinActual)
        {
            mejorScore = coinActual;
            scoreS.scoreMax = mejorScore;
        }
    }
}
