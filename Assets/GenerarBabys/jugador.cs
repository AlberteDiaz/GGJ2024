using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class jugador : MonoBehaviour
{
    public int vida = 100;
    public GameObject muerte;
    public GameObject[] enemigos;
    public int esteGM;
    string enemigo;
    public GameObject[] corazon;
    public GameObject[] corazonApagado;

    public bool puedoEmpujar = true;
    public bool puedoCaramelo = true;

    public GameObject areaCosquillas;
    public GameObject caramelo;
    // Start is called before the first frame update
    void Start()
    {
        if (esteGM == 1)
        {
            enemigo = "enemigo";
           
        }
        else if (esteGM == 2)
        {
            enemigo = "enemigo2";
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            cosquillas();
        }

    }
    
    public void perderVida(int cantidad)
    {
        vida = vida - cantidad;
        
        if(vida == 100)
        {
            corazon[0].SetActive(true);
            corazon[1].SetActive(true);
            corazon[2].SetActive(true);
            corazon[3].SetActive(true);
        }
        else if(vida <= 80 && vida > 60)
        {
            corazon[0].SetActive(true);
            corazon[1].SetActive(true);
            corazon[2].SetActive(true);
            corazon[3].SetActive(false);
            corazonApagado[3].SetActive(true);
        }
        else if(vida <= 60 && vida > 40)
        {
            corazon[0].SetActive(true);
            corazon[1].SetActive(true);
            corazon[2].SetActive(false);
            corazon[3].SetActive(false);
            corazonApagado[3].SetActive(true);
            corazonApagado[2].SetActive(true);
        }
        else if(vida <= 40 && vida > 20)
        {
            corazon[0].SetActive(true);
            corazon[1].SetActive(false);
            corazon[2].SetActive(false);
            corazon[3].SetActive(false);
            corazonApagado[3].SetActive(true);
            corazonApagado[2].SetActive(true);
            corazonApagado[1].SetActive(true);
        }
        else if(vida <= 20)
        {
            corazon[0].SetActive(false);
            corazon[1].SetActive(false);
            corazon[2].SetActive(false);
            corazon[3].SetActive(false);
            corazonApagado[3].SetActive(true);
            corazonApagado[2].SetActive(true);
            corazonApagado[1].SetActive(true);
            corazonApagado[0].SetActive(true);
        }

        if (vida <= 0)
        {
            //muerte.SetActive(true);
            Destroy(this.gameObject);
            
        }
    }

    IEnumerator empujeBebe()
    {
        puedoEmpujar = false;

        enemigos = GameObject.FindGameObjectsWithTag(enemigo);

        for (int i = 0; i<enemigos.Length; i++)
        {
            enemigos[i].GetComponent<bebe>().speed = -enemigos[i].GetComponent<bebe>().speed;
        }

        yield return new WaitForSeconds(1.6f);

        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].GetComponent<bebe>().speed = -enemigos[i].GetComponent<bebe>().speed;
        }
        yield return new WaitForSeconds(1.4f);
        puedoEmpujar = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == enemigo)
        {
            
            perderVida(collision.gameObject.GetComponent<bebe>().daño);
            Destroy(collision.gameObject);
        }
    }
    IEnumerator caramelillo()
    {
        enemigos = GameObject.FindGameObjectsWithTag(enemigo);
        puedoCaramelo = false;

        GameObject esteCaramelo = Instantiate(caramelo, transform.position, Quaternion.identity);
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].GetComponent<bebe>().target = caramelo;
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < enemigos.Length; i++)
        {
            enemigos[i].GetComponent<bebe>().irAJugador();
        }
        Destroy(esteCaramelo);
        puedoCaramelo =true;
    }
    public void caramelos()
    {
        if (puedoCaramelo)
        {
            StartCoroutine(caramelillo());
        }
    }

    public void empujon()
    {
        if (puedoEmpujar)
        {
            StartCoroutine(empujeBebe());
        }
    }

    public void cosquillas()
    {
        StartCoroutine(puedoCosquillas());
    }
    IEnumerator puedoCosquillas()
    {
        areaCosquillas.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        areaCosquillas.SetActive(false);
    }
}
