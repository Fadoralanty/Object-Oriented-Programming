using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IBox
    {
        BoxCollider boxCollider { get; }

        void SetGrab(bool isGrabbed);

        void OnCollisionEnterHandler(BoxCollider boxCollider);
    }
}