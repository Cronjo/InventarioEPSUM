using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoItem", menuName = "Inventario/ItemData")]
public class InventarioScriptableObjects : ScriptableObject
{
    public string Nombre;
    public int Cantidad;
    public Sprite Icono;
    public TipoItem tipoItem;
    public bool esItemEspecial; //Bool para saber si se trata de la mochila

    // Posición en el inventario 
    public int indiceSlot = -1;
}

public enum TipoItem {Espada, Collar, Moneda, Mochila, Manzana, Pocion, Gema}
