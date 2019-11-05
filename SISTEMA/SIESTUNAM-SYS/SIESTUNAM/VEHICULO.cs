using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIESTUNAM
{
    public class VEHICULO
    {
        int idAuto;

        public int IdAuto
        {
            get { return idAuto; }
            set { idAuto = value; }
        }
        string marca;

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        string placas;

        public string Placas
        {
            get { return placas; }
            set { placas = value; }
        }
        string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        int idUser;

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public VEHICULO(int idAuto, string marca, string modelo, string placas, string color, int tipo, int idUser)
        {
            this.idAuto = idAuto;
            this.marca = marca;
            this.modelo = modelo;
            this.placas = placas;
            this.color = color;
            this.tipo = tipo;
            this.idUser = idUser;            
        }
        
    }
}
