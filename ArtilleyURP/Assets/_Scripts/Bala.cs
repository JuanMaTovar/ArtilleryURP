using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject particulasExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Invoke("Explotar", 2);
        }
        if (collision.gameObject.CompareTag("Obstaculo") || collision.gameObject.CompareTag("Objetivo")) Explotar();
    }
    public void Explotar()
    {
        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity) as GameObject;
        Canon.Bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
}
