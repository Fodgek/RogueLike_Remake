using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike_Remake.Renderer
{
    internal interface IRenderer
    {
        public void RenderFrame();
        public void ClearFrame();
    }
}
