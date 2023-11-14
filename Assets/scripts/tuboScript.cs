using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuboScript : MonoBehaviour
{

    public float speed=-5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "killTubos")
        {
            poolTubos.devolverEnemy(this.gameObject);
          /*  float rand = Random.Range(-1, 1);
            this.transform.position = new Vector3(transform.position.x, transform.position.y + rand, transform.position.z);
            */
        }
    }
}
