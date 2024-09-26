using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pijaca
{
    public interface IInspekcija
    {
        public bool ŠtandIspravan(Štand š);
    }
   
    public class Inspekcija : IInspekcija
    {
        public bool ŠtandIspravan(Štand š)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Implementirao Armin Hadzic 18667
    /// </summary>
    public class StubInspekcija : IInspekcija
    {
        public bool ŠtandIspravan(Štand š)
        {
            return false;
        }
    }
}
