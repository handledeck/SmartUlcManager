using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Uart.Attributes
{
   /// <summary>
   /// 
   /// </summary>
   public abstract class BaseTypeDescriptionProvider : TypeDescriptionProvider, IDisposable
   {
      #region Private Class BaseTypeDescriptor

      /// <summary>
      /// 
      /// </summary>
      private class BaseTypeDescriptor : CustomTypeDescriptor
      {
         #region Members

         private BaseTypeDescriptionProvider owner = null;
         private Type objectType = null;
         private object instance = null;

         #endregion

         #region Constructors

         /// <summary>
         /// Initializes a new instance of the <see cref="BaseTypeDescriptor"/> class.
         /// </summary>
         /// <param name="owner">The owner.</param>
         /// <param name="objectType">Type of the object.</param>
         /// <param name="instance">The instance.</param>
         public BaseTypeDescriptor(BaseTypeDescriptionProvider owner, Type objectType, object instance)
         {
            this.owner = owner;
            this.objectType = objectType;
            this.instance = instance;
         }

         #endregion

         #region Methods

         /// <summary>
         /// Gibt einen Typkonverter für den durch diesen Typdeskriptor dargestellten Typ zurück.
         /// </summary>
         /// <returns>
         /// Ein <see cref="T:System.ComponentModel.TypeConverter"></see> für den von diesem Typdeskriptor dargestellten Typ. Der Standard ist ein neu erstellter <see cref="T:System.ComponentModel.TypeConverter"></see>.
         /// </returns>
         public override TypeConverter GetConverter()
         {
            return owner.GetConverter(objectType, instance);
         }

         #endregion
      }

      #endregion

      #region Members

      private Type targetType = null;
      private bool disposed = false;

      #endregion

      #region Constructors

      protected BaseTypeDescriptionProvider(Type targetType)
         : base(TypeDescriptor.GetProvider(targetType))
      {
         TypeDescriptor.AddProvider(this, targetType);
         this.targetType = targetType;
      }

      ~BaseTypeDescriptionProvider()
      {
         if (!disposed)
            Dispose(false);
      }

      #endregion

      #region Methods

      protected abstract TypeConverter GetConverter(Type objectType, object instance);

      /// <summary>
      /// Liefert den EnumTypeConverter, wenn ein Enum-Type abgefragt wird
      /// </summary>
      /// <param name="objectType">Der Objekttyp, für den der Typdeskriptor abgerufen wird.</param>
      /// <param name="instance">Eine Instanz des Typs. Kann null sein, wenn keine Instanz an den <see cref="T:System.ComponentModel.TypeDescriptor"></see> übergeben würde.</param>
      /// <returns>
      /// Ein <see cref="T:System.ComponentModel.ICustomTypeDescriptor"></see>, der Metadaten für den Typ bereitstellen kann.
      /// </returns>
      public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
      {
         if (targetType.IsAssignableFrom(objectType))
            return new BaseTypeDescriptor(this, objectType, instance);
         else
            return base.GetTypeDescriptor(objectType, instance);
      }

      /// <summary>
      /// Releases unmanaged and - optionally - managed resources
      /// </summary>
      /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
      protected virtual void Dispose(bool disposing)
      {
         disposed = true;
         if (disposing)
         {
            TypeDescriptor.RemoveProvider(this, typeof(Enum));
            GC.SuppressFinalize(this);
         }
      }

      /// <summary>
      /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
      /// </summary>
      public void Dispose()
      {
         if (!disposed)
            Dispose(true);
      }

      #endregion
   }
}
