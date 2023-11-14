using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolTubos : MonoBehaviour
{
    public GameObject tubos;
    public static List<GameObject> tubosList;
    public Vector3 posInicial;
    public int rand;
    public float guardador;
    // Start is called before the first frame update
    void Awake()
    {
       
        tubosList = new List<GameObject>();
        for(int i=0; i <= 7; i++)
        {
          /*  Instantiate(tubos, posInicial, tubos.transform.rotation);
            tubos.SetActive(false);
            tubosList.Add(tubos);
            /*int x = Random.Range(5, 15);
            posInicial.z += x;*/

            GameObject nuevoTubo = Instantiate(tubos, posInicial, tubos.transform.rotation);
            nuevoTubo.SetActive(false);
            tubosList.Add(nuevoTubo);

        }
    }

    private void Start()
    {
         guardador = posInicial.y;
        mandarTubo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mandarTubo()
    {
        if (tubosList.Count > 0)
        {
          //  posInicial = guardador;
            posInicial.y = guardador;
            float posR = Random.Range(-1.5f, 1.5f);
            posInicial.y += posR;
            tubosList[0].transform.position = posInicial;
            tubosList[0].SetActive(true);
            tubosList.RemoveAt(0);
        }
         rand = Random.Range(1, 4);
        Invoke("mandarTubo", rand);
    }

    public static void devolverEnemy(GameObject tubo)
    {
        tubosList.Add(tubo);
        tubo.SetActive(false);
    }
}
