using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static int VelocidadBala = 30;
    public static int DisparosPorJuego = 3;
    public static float VelocidadRotacion = 1;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    private void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DisparosPorJuego <= 0 && Canon.Bloqueado == false)
        {
            PerderJuego();
        }
    }

    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
        
    }

    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
        
    }
}
