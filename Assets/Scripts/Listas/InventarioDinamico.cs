using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioDinamico : MonoBehaviour
{
    [SerializeField] private List<Slot> slots = new List<Slot>(); //Creo la lista de slots
    [SerializeField] private int capacidadMaxima = 4; //Cantidad de slots iniciales
    [SerializeField] private Sprite spriteVacio; //No quiero que quede una imagen en blanco

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
            for (int i = 0; i < slots.Count; i++) //Busco si el objeto existe en la lista y suma una unidad
            {
                if (slots[i].estaLleno && slots[i].objetoEnSlot == objeto)
                {
                    slots[i].objetoEnSlot.Cantidad++;
                    slots[i].textoCantidad.text = slots[i].objetoEnSlot.Cantidad.ToString();
                    return;
                }
            }

            for (int i = 0; i < capacidadMaxima && i < slots.Count; i++) //Si no existe, busco la primera posicion vacia para colocar el objeto
            {
                if (!slots[i].estaLleno) //Si el slot no esta lleno, entonces coloca el objeto en el espacio
                {
                    slots[i].objetoEnSlot = objeto;
                    slots[i].icono.sprite = objeto.Icono;
                    slots[i].objetoEnSlot.Cantidad++;
                    slots[i].textoCantidad.text = slots[i].objetoEnSlot.Cantidad.ToString();
                    return;
                }
            }

            Debug.Log("Inventario lleno");

        }
    }

    public void EliminarItemLista()
    {
        
    }
    public void AumentarCapacidad(int ranurasExtra)
    {
        capacidadMaxima += ranurasExtra; //Sumo la cantidad que se ponga en el parametro de entrada
    }
}
