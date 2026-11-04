using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListas : MonoBehaviour
{
    //Referencio el scriptable object
    public InventarioScriptableObjects objeto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Si existe el inventario mete el tipo de item al metodo de añadir item
            var inventario = FindObjectOfType<InventarioDinamico>();
            if (inventario != null)
            {
                inventario.AñadirItem(objeto);
            }

            Debug.Log("Objeto recogido: " + objeto);
            gameObject.SetActive(false);
        }
    }
}
