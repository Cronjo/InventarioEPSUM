using System;
using UnityEngine;

public class InventarioSlots : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

    [SerializeField] private Sprite spriteVacio; //No quiero que quede una imagen en blanco, si no 

    // Como quiero que al iniciar la escena, cargue en el inventario aquellos objetos que aun tenian unidades, creo un array con mis Scriptable Objects
    [SerializeField] private InventarioScriptableObjects[] todosLosItems;

    private void Start()
    {
        RestaurarInventario();
    }

    private void RestaurarInventario()
    {
        for (int i = 0; i < todosLosItems.Length; i++)
        {
            Debug.Log(todosLosItems[i]);
            Debug.Log("Mayonesa");
            if (todosLosItems[i].Cantidad > 0 && todosLosItems[i].indiceSlot >= 0)
            {
                
                int pos = todosLosItems[i].indiceSlot;

                if (pos < slots.Length)
                {
                    slots[pos].objetoEnSlot = todosLosItems[i];
                    slots[pos].icono.sprite = todosLosItems[i].Icono;
                    slots[pos].textoCantidad.text = todosLosItems[i].Cantidad.ToString();
                }
            }
        }
    }
    public void AñadirItem(InventarioScriptableObjects objeto)
    {
        //Primero, busca si el objeto existe en algun slot 

        bool encontrado = false;

        //Recorro buscando el objeto en algun slot

        for (int i = 0; i < slots.Length; i++)
        {
            if (encontrado == false && slots[i].estaLleno && slots[i].objetoEnSlot == objeto)
            {
                slots[i].objetoEnSlot.Cantidad++;
                slots[i].textoCantidad.text = slots[i].objetoEnSlot.Cantidad.ToString();
                encontrado = true;
            }
        }

        //Segundo,verifica que haya un slot vacio y solo llenar ese primer slot vacio
        if (encontrado == false)
        {
            bool colocado = false;

            for (int i = 0; i < slots.Length; i++)
            {
                if (colocado == false && slots[i].estaLleno == false)
                {
                    slots[i].objetoEnSlot = objeto;
                    slots[i].icono.sprite = objeto.Icono;
                    slots[i].objetoEnSlot.Cantidad++;
                    slots[i].objetoEnSlot.indiceSlot = i;   // Guarda la posición en el array para el inventario 
                    slots[i].textoCantidad.text = slots[i].objetoEnSlot.Cantidad.ToString(); 
                    colocado = true;
                }
            }

            if (colocado == false) //Si no hay slots vacios entonces inventario lleno
            {
                Debug.Log("Inventario lleno");
            }
        }
    }

    //Tercero, eliminar una unidad al dar click al slot
    public void EliminarItem(int indiceSlot)
    {
        if (slots[indiceSlot].estaLleno) //Busca si hay algun objeto en el slot clickado (1, 2 o 3)
        {
            slots[indiceSlot].objetoEnSlot.Cantidad--; //Resta una unidad

            if (slots[indiceSlot].objetoEnSlot.Cantidad <= 0) //Si llega a 0 limpia el slot
            {
                slots[indiceSlot].objetoEnSlot.indiceSlot = -1;   //Deja libre la posición en el inventario
                slots[indiceSlot].objetoEnSlot = null;
                slots[indiceSlot].icono.sprite = spriteVacio;
                slots[indiceSlot].textoCantidad.text = ".";
            }
            else
            {
                slots[indiceSlot].textoCantidad.text = slots[indiceSlot].objetoEnSlot.Cantidad.ToString(); // Si no, se asegura de poner el valor de la cantidad
            }
        }
    }

    #region Codigo inutil de pruebas

    /*[SerializeField] private TMP_Text[] textosCantidad;
    [SerializeField] private Button[] botonesSlot;
    [SerializeField] private Image[] iconos;
    [SerializeField] private InventarioScriptableObjects[] objetos;
    private bool llenado = false;

    private void Start()
    {
        Actualizar();
    }

    public void Actualizar()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objetos[i] != null && objetos[i].Cantidad > 0)
            {
                iconos[i].sprite = objetos[i].Icono;
                textosCantidad[i].text = objetos[i].Cantidad.ToString();
            }

            else
            {
                iconos[i].sprite = null;
                textosCantidad[i].text = Convert.ToString(0);
            }
        }
    }

    public void EliminarItem(int slotBoton)
    {
        if (slotBoton >= 0 && objetos[slotBoton] != null)
        {
            Debug.Log("Langostas se han comido un objeto!");
            objetos[slotBoton].Cantidad--;
            if (objetos[slotBoton].Cantidad <= 0)
            {
                objetos[slotBoton].Cantidad = 0;
            }
        }

        Actualizar();
    }

        /*[SerializeField] private InventarioScriptableObjects objeto;
        [SerializeField] private Image icono;
        [SerializeField] private TMP_Text textoCantidad;

        private void Start()
        {
            Inicializar();
        }

        public void Inicializar()
        {
            if (objeto != null)
            {
                icono.sprite = objeto.Icono;
                textoCantidad.text = objeto.Cantidad.ToString();
            }
        }

        public void Actualizar()
        {
            if (objeto != null)
            {
                Debug.Log("Se deberia imprimir el valor" + objeto);
                textoCantidad.text = objeto.Cantidad.ToString();
            }
        }*/
    #endregion
}
