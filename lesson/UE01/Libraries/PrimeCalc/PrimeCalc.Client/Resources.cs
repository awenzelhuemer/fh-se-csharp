using System.Resources;

namespace PrimeCalc.Client
{
  internal class Resources
  {
    private static ResourceManager resourceManager;
    
    private static ResourceManager ResourceManager =>
      resourceManager ??= new ResourceManager("PrimeCalc.Client.Resources.Messages",
                                              typeof(Resources).Assembly);

    public static string GetString(string resourceName) =>
      ResourceManager.GetString(resourceName);
  }
}