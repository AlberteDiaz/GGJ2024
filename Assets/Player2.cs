using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 2f;

    public GameObject balaPrefab;
    public float balaVelocidad;
    public Vector3 direccionBala;

    public bool puedoDisparo = true;
    public int id;
    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
    public GameObject direccion;
    public Animator anim;
    public Animator[] animArray;
    public GameObject jugador;
    public GameObject[] jugadores;
    public GameObject cubo;

    // Start is called before the first frame update
    void Start()
    {
        anim = animArray[id];
        jugador = jugadores[id];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        float x = Input.GetAxis("EjeX");
        float z = Input.GetAxis("EjeY");
        if (x > 0)
        {
            direccion = d;
            direccionBala = transform.right;
            pos.x += speed * Time.deltaTime;
            anim.SetTrigger("Move");
        }
        else if (x < 0)
        {
            direccion = a;
            direccionBala = -transform.right;
            pos.x -= speed * Time.deltaTime;
            anim.SetTrigger("Move");
        }
        if (z > 0)
        {
            direccion = w;
            direccionBala = transform.forward;
            pos.z += speed * Time.deltaTime;
            anim.SetTrigger("Move");
        }
        else if (z < 0)
        {
            direccion = s;
            direccionBala = -transform.forward;
            pos.z -= speed * Time.deltaTime;
            anim.SetTrigger("Move");
        }
        else if (x == 0 && z == 0)
        {
            anim.SetTrigger("Idle");
        }



        Vector3 movDir = new Vector3(x, 0, z);
        movDir.Normalize();
        if (movDir != Vector3.zero)
        {
            jugador.transform.forward = movDir;
        }
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (puedoDisparo)
            {
                anim.SetTrigger("A1");
                GameObject balaTemporal = Instantiate(balaPrefab, direccion.transform.position, Quaternion.identity) as GameObject;

                Rigidbody rb = balaTemporal.GetComponent<Rigidbody>();

                rb.AddForce(direccionBala * balaVelocidad);

                Destroy(balaTemporal, 3f);
                GameManager.Instance.useAbility(0, "Z", 1);
                StartCoroutine(disparo());
            }
            



            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("A2");
            this.gameObject.GetComponent<jugador>().caramelos();
            GameManager.Instance.useAbility(1, "X", 3);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("A3");
            this.gameObject.GetComponent<jugador>().empujon();
            GameManager.Instance.useAbility(2, "C", 3);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.gameObject.GetComponent<jugador>().cosquillas(); 
            anim.SetTrigger("A4");
            GameManager.Instance.useAbility(3, "V", 3);
        }

        

        IEnumerator disparo()
        {
            puedoDisparo = false;
            yield return new WaitForSeconds(0.3f);
            puedoDisparo = true;
        }

    }
}
