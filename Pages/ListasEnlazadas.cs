// ListasEnlazadas.cs
using System;

namespace BlazorListApp.Models
{
    public class NodoLista
    {
        public int Dato { get; set; }
        public NodoLista Siguiente { get; set; }

        public NodoLista(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class ListasEnlazadas
    {
        public NodoLista EHM { get; set; }

        public void AgregarAlInicio(int dato)
        {
            NodoLista nuevoNodo = new NodoLista(dato);
            nuevoNodo.Siguiente = EHM;
            EHM = nuevoNodo;
        }

        public void AgregarAlFinal(int dato)
        {
            NodoLista nuevoNodo = new NodoLista(dato);
            if (EHM == null)
            {
                EHM = nuevoNodo;
                return;
            }
            NodoLista ultimoNodo = ObtenerUltimoNodo();
            ultimoNodo.Siguiente = nuevoNodo;
        }

        public void AgregarEnPosicion(int posicion, int nuevoDato)
        {
            if (posicion < 1) return;
            NodoLista nuevoNodo = new NodoLista(nuevoDato);

            if (posicion == 1)
            {
                nuevoNodo.Siguiente = EHM;
                EHM = nuevoNodo;
                return;
            }

            NodoLista actual = EHM;
            int contador = 1;
            while (contador < posicion - 1 && actual != null)
            {
                actual = actual.Siguiente;
                contador++;
            }

            if (actual != null)
            {
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;
            }
        }

        public void RecorrerRecursivamente(NodoLista nodo)
        {
            if (nodo == null) return;
            Console.WriteLine(nodo.Dato);
            RecorrerRecursivamente(nodo.Siguiente);
        }

        public bool Buscar(int dato)
        {
            NodoLista actual = EHM;
            while (actual != null)
            {
                if (actual.Dato == dato) return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public void IniciarRecorridoRecursivo()
        {
            RecorrerRecursivamente(EHM);
        }

        private NodoLista ObtenerUltimoNodo()
        {
            NodoLista temp = EHM;
            while (temp.Siguiente != null)
            {
                temp = temp.Siguiente;
            }
            return temp;
        }
    }
}
