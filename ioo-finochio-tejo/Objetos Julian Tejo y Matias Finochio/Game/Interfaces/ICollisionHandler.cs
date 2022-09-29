using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface ICollisionHandler
    {
        void GrabItem(Box other);
        void DropItem();

        void OnCollisionEnterHandler(BoxCollider other);

        void OnCollisionStayHandler(BoxCollider other);

    }
}