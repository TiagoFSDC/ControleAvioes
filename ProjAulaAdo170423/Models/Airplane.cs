using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAulaAdo170423.Models;

namespace ProjAulaAdo170423.Model
{
    public class Airplane
    {
        #region Propertires
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberofPassangers { get; set; }
        public string Description { get; set; }
        public Engine Engine { get; set; }
        #endregion

        public override string ToString()
        {
            return "Id: " + Id+
                "\nNome: " + Name+
                "\nNumero de passageiros: " + NumberofPassangers+
                "\ndescrição: " + Description+
                "\nMotor"+ Engine;
        }
    }
}
