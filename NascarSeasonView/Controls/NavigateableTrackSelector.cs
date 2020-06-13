using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENG.NR2003.Types;

namespace ENG.NR2003.NascarSeasonView.Controls
{
  public partial class NavigateableTrackSelector : UserControl
  {

    public event EventHandler CurrentChanged;    

    private class ComboBoxItem
    {
      public WeekendInfo Item;
      public string Text;

      public ComboBoxItem(WeekendInfo item, string text)
      {
        this.Item = item;
        this.Text = text;
      }

      public override string ToString()
      {
        return Text;
      }
    }

    public NavigateableTrackSelector()
    {
      InitializeComponent();
    }

    private void NavigateableTrackSelector_Resize(object sender, EventArgs e)
    {
      AdjustSize();
    }

    private void AdjustSize()
    {
      this.Height = cmbRaces.Height;
      this.btnLast.Width = this.Height;
      this.btnNext.Width = this.Height;
      this.btnPrevious.Width = this.Height;
    }

    public WeekendInfo Current
    {
      get
      {
        if (cmbRaces.SelectedItem == null)
          return null;
        else
          return (cmbRaces.SelectedItem as ComboBoxItem).Item;
      }
    }

    WeekendInfoCollection wds = null;
    public void RefreshData(WeekendInfoCollection datas)
    {
      this.wds = datas;
      RefreshComboBoxItem(false);
      TrySelectLastComboBoxItemIndex();
    }

    private void TrySelectLastComboBoxItemIndex()
    {
      if (cmbRaces.Items.Count > 0)
        cmbRaces.SelectedIndex = cmbRaces.Items.Count - 1;
    }

    private void RefreshComboBoxItem(bool preserveSelectedIndex)
    {
      int index = cmbRaces.SelectedIndex;

      cmbRaces.Items.Clear();

      if (wds == null) return;

      foreach (var item in wds)
      {
        AddComboBoxItem(item);
      }

      if (cmbRaces.Items.Count > index && preserveSelectedIndex)
        cmbRaces.SelectedIndex = index;
    }    

    private void AddComboBoxItem(WeekendInfo data)
    {
      ComboBoxItem cbi = new ComboBoxItem(data, 
        (cmbRaces.Items.Count + 1) + ". " + data.Weekend.Name);
      cmbRaces.Items.Add(cbi);
    }

    private void cmbRaces_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (CurrentChanged != null)
        CurrentChanged(this, new EventArgs());
    }

    private void NavigateableTrackSelector_Load(object sender, EventArgs e)
    {
      AdjustSize();
    }

  }
}
