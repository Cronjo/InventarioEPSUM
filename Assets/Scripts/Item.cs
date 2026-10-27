using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static Item;

public class Item : MonoBehaviour
{
    //Referencio el scriptable object
    [SerializeField] private InventarioScriptableObjects objeto;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Accedo a la cantidad del scriptableobject y le sumo una unidad
            objeto.Cantidad++; 

            FindFirstObjectByType<InventarioSlots>().Actualizar();

            Debug.Log("Langostas");
            gameObject.SetActive(false);
        }
    }
}
