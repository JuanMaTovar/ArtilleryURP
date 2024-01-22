using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuGanar;
    public GameObject menuPerder;
    
    
    //public GameObject menuOpciones;

    public void MostrarMenuPausa()
    {
        menuPausa.SetActive(true);
        //if (menuOpciones.activeInHierarchy) menuOpciones.SetActive(false);
    }
    public void IniciarJuego()
    {
        AdministradorJuego.DisparosPorJuego = 3;
        SceneManager.LoadScene(1);
        

    }
    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }
    public void RegresarAPantallaPrincipal()
    {
        
        SceneManager.LoadScene(0);

        
    }

    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        //menuOpciones.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
