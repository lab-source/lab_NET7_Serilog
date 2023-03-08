namespace lab_NET7_Serilog.Service;

public interface ITestService
{
    Task<string> Search(string searchKey);
}