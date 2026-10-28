using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonReinicio : MonoBehaviour
{
    [SerializeField] private InventarioScriptableObjects[] objetos;

    [ContextMenu("Reiniciar cantidades de los objetos")]
    public void ReiniciarValores()
    {
        foreach (InventarioScriptableObjects item in objetos)
        {
            if (item != null)
            {
                item.Cantidad = 0;
            }
        }
    }
}
