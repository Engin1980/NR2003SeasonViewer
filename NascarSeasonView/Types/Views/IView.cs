using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENG.NR2003.NascarSeasonView.Types.Views
{
  public interface IView<T>
  {
    List<T> GetAll();
  }
}
