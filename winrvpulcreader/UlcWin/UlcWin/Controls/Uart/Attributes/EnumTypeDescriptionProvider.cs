using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Uart.Attributes
{
   public class EnumTypeDescriptionProvider : BaseTypeDescriptionProvider
   {
      #region Constructors

      public EnumTypeDescriptionProvider()
         : base(typeof(Enum))
      {
      }

      #endregion

      protected override TypeConverter GetConverter(Type objectType, object instance)
      {
         return new EnumTypeConverter(objectType);
      }
   }
}
