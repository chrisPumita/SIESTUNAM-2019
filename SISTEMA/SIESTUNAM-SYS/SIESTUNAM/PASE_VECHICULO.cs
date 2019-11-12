using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIESTUNAM
{
    class PASE_VECHICULO
    {
        private int idPase;

        public int IdPase
        {
            get { return idPase; }
            set { idPase = value; }
        }
        private int idAuto;

        public int IdAuto
        {
            get { return idAuto; }
            set { idAuto = value; }
        }
        private int idEmp;

        public int IdEmp
        {
            get { return idEmp; }
            set { idEmp = value; }
        }
        private int reporte;

        public int Reporte
        {
            get { return reporte; }
            set { reporte = value; }
        }
        private DateTime horaE;

        public DateTime HoraE
        {
            get { return horaE; }
            set { horaE = value; }
        }
        private DateTime horaS;

        public DateTime HoraS
        {
            get { return horaS; }
            set { horaS = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public PASE_VECHICULO(int idPase,int idAuto,int idEmp,int IdReporte,DateTime horaE,DateTime horaS,int status) 
        {
            this.IdPase  = idPase;
            this.IdEmp   = idEmp;
            this.IdAuto  = idAuto;
            this.Reporte = IdReporte;
            this.HoraE   = horaE;
            this.HoraS   = horaS;
            this.Status  = status;
        }

        public PASE_VECHICULO(int idPase, int idAuto, int idEmp, DateTime horaE, int status)
        {
            this.IdPase = idPase;
            this.IdEmp = idEmp;
            this.IdAuto = idAuto;
            this.HoraE = horaE;
            this.Status = status;
        }
    }
}
