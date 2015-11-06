using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Enumerator : IEnumerator
    {
        private Vector vector;
        private int position = -1;
        public Enumerator(Vector vector)
        {
            this.vector = vector;
        }       

        public bool MoveNext()
        {
            position++;
            return (position < vector.Count());
        }

        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                return vector.GetElementAtIndex(position);
            }
        }        
    }
}
