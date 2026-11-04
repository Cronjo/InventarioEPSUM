using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioDinamico : MonoBehaviour
{
    [SerializeField] private List<Slot> slots = new List<Slot>(); //Creo la lista de slots
    [SerializeField] private int slotsVisibles = 3; // Slots que inician
    [SerializeField] private int maximoSlotsPosibles = 6; // Cantidad maxima slots
    [SerializeField] private Sprite spriteVacio; //No quiero que quede una imagen en blanco
    private void Start()
    {
        ActualizarVisibilidadSlots();
        RefrescarUI();
    }

    // Activa los slots que esten visibles segun la cantidad
    private void ActualizarVisibilidadSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].gameObjectSlot != null)
            {
                slots[i].gameObjectSlot.SetActive(i < slotsVisibles);
            }
        }
    }
    public void AñadirItem(InventarioScriptableObjects objeto)
    {
        //Primero verifico si es el item especial (mochila)
        if (objeto.esItemEspecial == true)
        {
            AumentarCapacidad(1); // Si es, entonces suma la cantidad que pase como parametro de entrada
            return;
        }

        else
        {
            for (int i = 0; i < slotsVisibles; i++) //Busco si el objeto existe en la lista y suma una unidad
            {
                if (slots[i].estaLleno && slots[i].objetoEnSlot == objeto)
                {
                    slots[i].objetoEnSlot.Cantidad++;
                    RefrescarUI();
                    return;
                }
            }

            for (int i = 0; i < slotsVisibles; i++)//Si no existe, busco la primera posicion vacia para colocar el objeto
            {
                if (!slots[i].estaLleno) //Si el slot no esta lleno, entonces coloca el objeto en el espacio
                {
                    slots[i].objetoEnSlot = objeto;
                    slots[i].objetoEnSlot.Cantidad = 1;
                    RefrescarUI();
                    return;
                }
            }

            Debug.Log("Inventario lleno");

        }
    }

    public void EliminarItemLista(int indiceSlot)
    {
        if (indiceSlot >= 0 && indiceSlot < slotsVisibles && slots[indiceSlot].estaLleno) //Busca el slot segun el numero que le asigne
        {
            slots[indiceSlot].objetoEnSlot.Cantidad--; //Borra una unidad del objeto

            if (slots[indiceSlot].objetoEnSlot.Cantidad <= 0)
            {
                slots[indiceSlot].objetoEnSlot = null;
                ReorganizarInventario(); // Reorganiza hacia la izquierda tras borrar
            }

            RefrescarUI();
        }
    }

    public void AumentarCapacidad(int ranurasExtra)
    {
        if (slotsVisibles < maximoSlotsPosibles)
        {
            slotsVisibles = Mathf.Min(slotsVisibles + ranurasExtra, maximoSlotsPosibles); //Si slotsvisibles + ranuras extra es menos que maximoslotsposibles entonces aumenta la cantidad
            ActualizarVisibilidadSlots();
            Debug.Log("Slots ampliados. Ahora visibles: " + slotsVisibles);
        }
    }

    private void ReorganizarInventario()
    {
        List<InventarioScriptableObjects> itemsActuales = new List<InventarioScriptableObjects>();

        // Agrupa todos los objetos que quedan en las casillas visibles en una lista
        for (int i = 0; i < slotsVisibles; i++)
        {
            if (slots[i].estaLleno)
            {
                itemsActuales.Add(slots[i].objetoEnSlot);
                slots[i].objetoEnSlot = null;
            }
        }

        // Recoloca desde el primer espacio
        for (int i = 0; i < itemsActuales.Count; i++) 
        {
            slots[i].objetoEnSlot = itemsActuales[i];
        }
    }

    private void RefrescarUI()
    {
        for (int i = 0; i < slotsVisibles; i++)
        {
            if (slots[i].estaLleno)
            {
                slots[i].icono.sprite = slots[i].objetoEnSlot.Icono;
                slots[i].textoCantidad.text = slots[i].objetoEnSlot.Cantidad.ToString();
            }
            else
            {
                slots[i].icono.sprite = spriteVacio;
                slots[i].textoCantidad.text = ".";
            }
        }
    }
}
