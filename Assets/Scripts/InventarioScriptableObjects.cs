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
}

public enum TipoItem { Espada, Collar, Moneda}
