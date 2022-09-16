using Dapper.Contrib.Extensions;

namespace Ztp.Model
{
  [Table("CatLightPlan")]
  public class LightPlan
  {
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
  }

  public static class LightPlanFld
  {
    public const string Id = "Id";
    public const string DisplayName = "DisplayName";
    public const string Description = "Description";
    public const string Body = "Body";
  }
}