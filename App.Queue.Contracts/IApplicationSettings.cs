namespace App.Queue.Contracts
{
    public interface IApplicationSettings
    {
        int Iterations { get; set;}
        string DefaultConnectionString { get; set; }
        string Digest { get; set; }
        string DefaultEncoding { get; set; }
    }
}
