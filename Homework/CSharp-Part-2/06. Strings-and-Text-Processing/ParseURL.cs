using System;
using System.Text;

class ParseURL
{
    static void Main()
    {
        string input = Console.ReadLine();

        var url = new Uri(input);
        string protocol = url.Scheme;
        string server = url.Host;
        string resource = url.PathAndQuery;

        var formatted = "[protocol] = {0}\n[server] = {1}\n[resource] = {2}";
        Console.WriteLine(formatted, protocol, server, resource);
    }
}