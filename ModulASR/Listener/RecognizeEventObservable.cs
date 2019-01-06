using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SterownikDialogu.Background.Listener
{
    public interface RecognizeEventObservable
    {
        void AddObserver(RecognizeEventObserver observer);
        void RemoveObserver(RecognizeEventObserver observer);
        void NotifyObserver(String message);
    }
}
