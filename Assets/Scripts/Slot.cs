using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

[System.Serializable]
public class Slot
{
    public Image icono;
    public TMP_Text textoCantidad;
    public InventarioScriptableObjects objetoEnSlot;

    // Devuelve true si tiene un objeto, false si está vacío
    public bool estaLleno
    {
        get { return objetoEnSlot != null; }
    }

}
