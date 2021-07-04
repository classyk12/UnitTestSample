using System;
using System.Collections.Generic;

namespace Unit_test_sample.Fundamentals
{
    public class Stack<T>
    {
      public readonly List<T> _list = new List<T>();
      public bool IsEmpty => Count == 0;
      public int Count => _list.Count;
      public void Push (T value)
      {
          _list.Add(value);
      }

       public void Pop ()
      {
         if(IsEmpty)
         throw new InvalidOperationException();

         _list.RemoveAt(Count - 1); 
      }

    public T Peek()
    {
        if(IsEmpty)
        throw new InvalidOperationException();

        
        return _list[Count-1];
    }

    }
}