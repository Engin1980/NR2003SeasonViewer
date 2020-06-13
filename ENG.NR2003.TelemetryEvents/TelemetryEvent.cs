using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics.Contracts;

namespace ENG.NR2003.TelemetryEvents
{
  [Serializable()]
  public abstract class TelemetryEvent
  {
    public static TelemetryEvent Create (string data)
    {
      Contract.Requires(data != null && data.Length > 0);

      TelemetryEvent ret = Analyser.DecodeLine(data);

      return ret;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append(this.GetType().Name);

      sb.Append("{");

      PropertyInfo[] ps = this.GetType().GetProperties();
      foreach (var fItem in ps)
      {
        sb.Append(fItem.Name + "=" + fItem.GetValue(this,null) + "; ");
      } // foreach (var fItem in ps)

      sb.Append("}");

      return sb.ToString();
    }
  }
}
