using System;
namespace Asm2
{
    public interface IIterator
    {
        Person CurrentItem();
        void First();
        bool IsDone();
        Person Next();
    }
}
