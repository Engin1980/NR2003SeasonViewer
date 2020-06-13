using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.NascarSeasonView.Types;
using ENG.NR2003.NascarSeasonView.Jobs.SimpleTelemetryLoading;
using ENG.NR2003.NascarSeasonView.Jobs.SmartTelemetryLoading;

namespace ENG.NR2003.NascarSeasonView.Forms
{
  public partial class FrmTelemetryView : Form
  {
    public FrmTelemetryView()
    {
      InitializeComponent();
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string fn = Dialogs.GetOpenTelemetry();

      var events = SimpleTelemetryLoader.LoadTelemetry(fn);
      var smart = SmartTelemetryAnalyser.AnalyseTelemetry(events);

      FillTree(smart);
      FillLists(events);
    }

    private void FillLists(TelemetryEvents.TelemetryEvent[] events)
    {
      lst.Items.Clear();
      lstTypes.Items.Clear();

      HashSet<Type> set = new HashSet<Type>();

      foreach (var item in events)
      {
        Type t = item.GetType();
        if (set.Contains(t) == false)
        {
          set.Add(t);
          
          lstTypes.Items.Add(new ListItem(t, t.Name));          
        }        
      }

      for (int i = 0; i < lstTypes.Items.Count; i++)
      {
        lstTypes.SetItemChecked(i, true);
      }

      lstTypes.Tag = events;

      RefreshEventsView();
    }

    private void FillTree(SessionBlock[] smart)
    {
      tvw.Nodes.Clear();

      Dictionary<TelemetryEvents.CurrentWeekend, TreeNode> weekendNodes = new Dictionary<TelemetryEvents.CurrentWeekend, TreeNode>();

      foreach (var sessionBlock in smart)
      {
        if (weekendNodes.ContainsKey(sessionBlock.CurrentWeekend) == false)
        {
          TreeNode y = new TreeNode() { Text = sessionBlock.CurrentWeekend.ToString() };
          weekendNodes.Add(
            sessionBlock.CurrentWeekend, y);
          tvw.Nodes.Add(y);
        }

        TreeNode weekendNode = weekendNodes[sessionBlock.CurrentWeekend];
        TreeNode sessionNode = new TreeNode() { Text = sessionBlock.SessionInfo.ToString() };
        weekendNode.Nodes.Add(sessionNode);

        foreach (var evnt in sessionBlock.Events)
        {
          TreeNode n = new TreeNode() { Text = evnt.ToString() };
          sessionNode.Nodes.Add(n);
        }
      }
    }

    private void lstTypes_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      RefreshEventsView(e.Index, e.NewValue);
    }

    private void RefreshEventsView(int clickedItemIndex, CheckState clickedItemNewState)
    {
      HashSet<Type> validTypes = new HashSet<Type>();
      for (int i = 0; i < lstTypes.Items.Count; i++)
      {
        if (lstTypes.CheckedIndices.Contains(i))
          validTypes.Add(
            (lstTypes.Items[i] as ListItem).Value as Type);
      }

      Type specialType = (lstTypes.Items[clickedItemIndex] as ListItem).Value as Type;
      if (clickedItemNewState == CheckState.Checked)
        validTypes.Add(specialType);
      else
        validTypes.Remove(specialType);

      RefreshEventsView(validTypes);
    }

    private void RefreshEventsView()
    {
      HashSet<Type> validTypes = new HashSet<Type>();
      for (int i = 0; i < lstTypes.Items.Count; i++)
      {
        if (lstTypes.CheckedIndices.Contains(i))
          validTypes.Add(
            (lstTypes.Items[i] as ListItem).Value as Type);
      }

      RefreshEventsView(validTypes);
    }
    private void RefreshEventsView(HashSet<Type> validTypes)
    {
      lst.Items.Clear();

      TelemetryEvents.TelemetryEvent[] events =
        (TelemetryEvents.TelemetryEvent[])lstTypes.Tag;
      if (events == null) return;

      int index = 0;
      foreach (var item in events)
      {
        if (validTypes.Contains(item.GetType()))
          lst.Items.Add(new ListItem(item, index + ". " + item.ToString()));

        index++;
      }
    }
  }
}
