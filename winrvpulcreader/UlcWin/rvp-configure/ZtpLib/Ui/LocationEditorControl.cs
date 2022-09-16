using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ztp.Ui
{
  public partial class LocationEditorControl : UserControl
  {
    private ZtpLocation _value;
    public ZtpLocation Value
    {
      get { return _value; }
      set
      {
        _value = value;
        Assign();
      }
    }

    void Assign()
    {
      if(_value == null)
        return;
      idLatitude.Value = (decimal)_value.Latitude;
      idLongitude.Value = (decimal) _value.Longitude;
      itzTz.Value = _value.TimeZone;
    }

    public LocationEditorControl()
    {
      InitializeComponent();
    }

    private void idLatitude_ValueChanged(object sender, EventArgs e)
    {
      if(_value != null)
        _value.Latitude = Convert.ToSingle(idLatitude.Value);
    }

    private void idLongitude_ValueChanged(object sender, EventArgs e)
    {
      if (_value != null)
        _value.Longitude = Convert.ToSingle(idLongitude.Value);

    }

    private void itzTz_ValueChanged(object sender, EventArgs e)
    {
      if (_value != null)
        _value.TimeZone = itzTz.Value;
    }

    public class ZtpLocation
    {
      public float Latitude { get; set; }
      public float Longitude { get; set; }
      public sbyte TimeZone { get; set; }

      public override string ToString()
      {
        return $"Широта:{Latitude} Долгота:{Longitude} Часовой пояс:{TimeZone}";
      }

      public static ZtpLocation GetDefault()
      {
        return new ZtpLocation(){Latitude = 55.91F, Longitude = 30.201F, TimeZone = 3};
      }
    }

  }
}
