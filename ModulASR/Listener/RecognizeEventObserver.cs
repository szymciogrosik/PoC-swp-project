using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SterownikDialogu.Background.Listener
{
    public interface RecognizeEventObserver
    {
        void Notify(String message);
    }
}
