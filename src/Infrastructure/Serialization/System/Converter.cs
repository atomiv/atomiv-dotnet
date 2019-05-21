namespace Optivem.Infrastructure.Serialization.System
{
    /// <summary>
    /// Converts string data into object of a certain type
    /// </summary>
    /// <param name="data">String data to be converted</param>
    /// <returns>Converted type</returns>
    public delegate object Converter(string data);
}