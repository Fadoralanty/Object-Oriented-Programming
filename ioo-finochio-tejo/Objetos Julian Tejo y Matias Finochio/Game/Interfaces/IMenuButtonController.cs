using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
     public interface IMenuButtonController
    {
        Button defaultButton { get; }
        void PressSelectedButton();
        void SelectButton(Button button);

    }
}