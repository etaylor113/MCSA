using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.DependencyInjection
{
    public interface IText
    {
        void Print();
    }

    class Format : IText
    {
        public void Print()
        {
            Console.WriteLine(" here is text format");
        }
    }

    class DependencyInjection
    {
        private IText _text;
        public DependencyInjection(IText t1)
        {
            this._text = t1;
        }
        public void Print()
        {
            _text.Print();
        }
    }
}
