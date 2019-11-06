using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIESTUNAM
{
    public class Empleado
    {
        private int idEmp;

        public int IdEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }

        private int noCuenta;

        public int NoCuenta
        {
            get { return noCuenta; }
            set { noCuenta = value; }
        }

        private string nomEmp;

        public string NomEmp
        {
            get { return nomEmp; }
            set { nomEmp = value; }
        }

        private string apP;

        public string ApP
        {
            get { return apP; }
            set { apP = value; }
        }

        private string apM;

        public string ApM
        {
            get { return apM; }
            set { apM = value; }
        }

        private string tel;

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int sex;

        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private int tipoCta;

        public int TipoCta
        {
            get { return tipoCta; }
            set { tipoCta = value; }
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private string psw;
        public string Psw
        {
            get { return psw; }
            set { psw = value; }
        }

        public Empleado(int idEmp, int noCuenta, string name, string app, string apm, string tel, string email, int sex, int tc, int status, string psw) 
        {
            this.idEmp = idEmp;
            this.noCuenta = noCuenta;
            this.nomEmp = name;
            this.apP = app;
            this.apM = apm;
            this.tel = tel;
            this.email = email;
            this.sex = sex;
            this.tipoCta = tc;
            this.status = status;
            this.psw = psw;
        }
    }

}
