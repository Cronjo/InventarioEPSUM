using UnityEngine;

public class InventarioSlots : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

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
                    slots[i].objetoEnSlot.Cantidad = 1;
                    slots[i].icono.sprite = objeto.Icono;
                    slots[i].textoCantidad.text = "1";
                    colocado = true;
                }
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
