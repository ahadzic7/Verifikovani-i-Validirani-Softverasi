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
    /// <summary>
    /// Implementirao Armin Hadzic 18667
    /// </summary>
    public class Inspekcija : IInspekcija
    {
        public bool ŠtandIspravan(Štand š)
        {
            return false;
        }
    }
}
