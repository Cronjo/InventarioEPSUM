using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventarioSlots : MonoBehaviour
{

    //[SerializeField] private TMP_Text[] textosCantidad;
    //[SerializeField] private InventarioScriptableObjects[] objetos;

    [SerializeField] private InventarioScriptableObjects objeto;
    [SerializeField] private Image icono;
    [SerializeField] private TMP_Text textoCantidad;

    private void Start()
    {
        Inicializar();
    }

    public void Inicializar()
    {
        if (objeto != null)
        {
            icono.sprite = objeto.Icono;
            textoCantidad.text = objeto.Cantidad.ToString();
        }
    }

    public void Actualizar()
    {
        if (objeto != null)
        {
            Debug.Log("Se deberia imprimir el valor" + objeto);
            textoCantidad.text = objeto.Cantidad.ToString();
        }
    }
}
