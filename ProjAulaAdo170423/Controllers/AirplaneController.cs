using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjAulaAdo170423.Model;
using ProjAulaAdo170423.Services;

namespace ProjAulaAdo170423.Controllers
{
    public class AirplaneController
    {

        public bool Insert(Airplane airplane)
        {
            return new AirplaneServices().Insert(airplane);
        }

        public List<Airplane> FindAll()
        {
            return new AirplaneServices().FindAll();
        }
    }
}
