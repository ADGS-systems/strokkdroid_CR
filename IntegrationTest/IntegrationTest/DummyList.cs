using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationTest.Interfaces;

namespace IntegrationTest
{
    public class DummyList : IBDG
    {
        public IEnumerable<string> GetList()
        {
            return lista;
        }

        List<string> lista = new List<string>();

        public DummyList()
        {
            lista.Add("Hola");
            lista.Add("Mundo");
            lista.Add("Goat");          
        }
    }
}
