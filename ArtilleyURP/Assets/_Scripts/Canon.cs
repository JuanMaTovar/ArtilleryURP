using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Canon : MonoBehaviour
{
    public static bool Bloqueado;

    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    
    private AudioSource SourceDisparo;

    [SerializeField] private GameObject BalaPrefab;
    public GameObject ParticulasDisparo;
    private GameObject puntaCanon;
    private float rotacion;
    public Slider slider;
    private float fuerza;
    

    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControls = new CanonControls();
    }

    private void OnEnable()
    {
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
        
        
    }
    private void OnDisable()
    {
        disparar.performed -= Disparar;
    }

    // Start is called before the first frame update
    void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
       // slider = GetComponent<Slider>(); //Obtengo el elemento Slider del UI
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(modificarFuerza.ReadValue<float>());

        //fuerza += modificarFuerza.ReadValue<float>() * slider.value; //tomar en cuenta el slider para la fuerza
        slider.value += modificarFuerza.ReadValue<float>() * slider.value;
        
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.VelocidadRotacion;
        if (rotacion <= 90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        GameObject temp = Instantiate(BalaPrefab, puntaCanon.transform.position, transform.rotation);

        Rigidbody tempRB = temp.GetComponent<Rigidbody>();
        SeguirCamara.objetivo = temp;
        Vector3 direccionDisparo = transform.rotation.eulerAngles;
        direccionDisparo.y = 90 - direccionDisparo.x;
        Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
        GameObject Particulas = Instantiate(ParticulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
        tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala * slider.value;
        AdministradorJuego.DisparosPorJuego--;
        SourceDisparo.Play();
        //SourceDisparo.PlayOneShot(clipDisparo);
        Bloqueado = true;
    }

   
}
