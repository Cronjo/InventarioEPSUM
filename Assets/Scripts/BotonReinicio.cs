using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonReinicio : MonoBehaviour
{
    [SerializeField] private InventarioScriptableObjects objeto;
    [SerializeField] private InventarioScriptableObjects objeto1;
    [SerializeField] private InventarioScriptableObjects objeto2;

    public void ReiniciarValores()
    {
        objeto.Cantidad = 0;
        objeto1.Cantidad = 0;
        objeto2.Cantidad = 0;
    }
}
