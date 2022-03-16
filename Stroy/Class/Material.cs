using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Stroy.Class
{
    class Material
    {
        public string image
        {
            get
            {
                if (image != null)
                {
                    return image;
                }
                else
                {
                    return "Resources/picture.png";
                }
            }
        }
    }
}
