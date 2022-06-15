using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BulletsPool< T>
    {
        private Queue<T> _elements;
        private Func<T> _elementGenerator;

        public BulletsPool(Func<T> elementGenerator)
        {
            _elements = new Queue<T>();
            _elementGenerator = elementGenerator;
        }

        public T GetElement()
        {
            T item;

            if (_elements.Count > 0)
            {
                item = _elements.Dequeue();
            }
            else
            {
                item = _elementGenerator();
            }

            return item;
        }

        public void ReleaseObject(T item)
        {
            _elements.Enqueue(item);
        }
    }
}

