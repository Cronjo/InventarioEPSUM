using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    //Referencio el scriptable object
    public InventarioScriptableObjects objeto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Si existe el inventario mete el tipo de item al metodo de añadir item
            var inventario = FindObjectOfType<InventarioSlots>();
            if (inventario != null)
            {
              inventario.AñadirItem(objeto);
            }

            Debug.Log("Objeto recogido: " + objeto);
            gameObject.SetActive(false);
        }
    }


    #region Codigo inutil de pruebas 
    /*
    //Referencio el scriptable object
    [SerializeField] private InventarioScriptableObjects objeto;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Accedo a la cantidad del scriptableobject y le sumo una unidad
            objeto.Cantidad++; 

            FindFirstObjectByType<InventarioSlots>().Actualizar();

            
            gameObject.SetActive(false);
        }
    }
    */

    #endregion
}
