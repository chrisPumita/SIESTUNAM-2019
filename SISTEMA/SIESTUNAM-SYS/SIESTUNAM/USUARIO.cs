using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIESTUNAM
{
    public class USUARIO
    {
        int idUser;

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }
        int noCta;

        public int NoCta
        {
            get { return noCta; }
            set { noCta = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string app;

        public string App
        {
            get { return app; }
            set { app = value; }
        }
        string apm;

        public string Apm
        {
            get { return apm; }
            set { apm = value; }
        }
        string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        int sex;

        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        int tipo;

        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public USUARIO(int id, int cta, string nom, string ap, string am, string tel, string email, int sex, int tipo, int status)
        {
            this.idUser = id;
            this.noCta = cta;
            this.nombre = nom;
            this.app = ap;
            this.apm = am;
            this.tel = tel;
            this.email = email;
            this.sex = sex;
            this.tipo = tipo;
            this.status = status;
        }
    }
}
