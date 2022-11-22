using System;
using System.Threading.Tasks;


namespace R5T.F0083.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Try.Instance.CreateProgramFile();
        }
    }
}