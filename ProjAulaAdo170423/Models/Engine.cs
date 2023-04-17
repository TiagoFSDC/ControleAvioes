using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjAulaAdo170423.Models
{
    public class Engine
    {
        public int Id { get; set; }
        public string Description { get; set; }


        public override string ToString()
        {
            return $"Descrição: {Description}";
        }
    }
}
