namespace Ztp.Port
{
  public interface IDriverClientBase
  {
    /// <summary>Получает значение, которое определяет, открыт ли канал</summary>
    bool IsOpen { get; }
    /// <summary>Открыть порт</summary>
    void Open();
    /// <summary>Закрыть порт</summary>
    void Close();
  }
}