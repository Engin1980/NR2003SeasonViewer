using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarSeasonView.Types.Exceptions
{
  [Serializable]
  public class ForUserException : Exception
  {
    public ForUserException(string message) : base(message) { }
    public ForUserException(string message, Exception inner) : base(message, inner) { }
    protected ForUserException(
    System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context)
      : base(info, context) { }
  }
}
