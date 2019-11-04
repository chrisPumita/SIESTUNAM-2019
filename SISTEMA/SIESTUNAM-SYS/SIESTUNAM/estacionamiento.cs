using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIESTUNAM
{
    class estacionamiento
    {
        int iDEstacionamiento;

        public int IDEstacionamiento
        {
            get { return iDEstacionamiento; }
            set { iDEstacionamiento = value; }
        }
        string nomEscuela;

        public string NomEscuela
        {
            get { return nomEscuela; }
            set { nomEscuela = value; }
        }
        int lugaresT;

        public int LugaresT
        {
            get { return lugaresT; }
            set { lugaresT = value; }
        }
        int ocupados;

        public int Ocupados
        {
            get { return ocupados; }
            set { ocupados = value; }
        }
        int disponibles;

        public int Disponibles
        {
            get { return disponibles; }
            set { disponibles = value; }
        }

        public estacionamiento(int iDEstacionamiento, string nomEscuela, int lugaresT, int ocupados, int disponibles) 
        {
            this.iDEstacionamiento = iDEstacionamiento;
            this.nomEscuela = nomEscuela;
            this.lugaresT = lugaresT;
            this.disponibles = disponibles;
            this.ocupados = ocupados;
        }


    }
}
