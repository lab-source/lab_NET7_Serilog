namespace lab_NET7_Serilog.logger;

public interface IMyLogger
{
    Task CallApi(Uri uri, HttpContent httpContent);

    Task ReceivedEvents(byte[] eventData);
    
    Task ForTest(string log);
}