using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parentables
{
  public interface IParentable<T> where T:class
  {
    T Parent { get; set; }
  }
}
