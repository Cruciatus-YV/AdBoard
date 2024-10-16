namespace AdBoard.DbMigrator;

public class Program
{
    /// <summary>
    /// �������� ����� ��� ������� ����������.
    /// ������� � ����������� ����, ��������� ����������� ������ � ��������� ����������.
    /// </summary>
    /// <param name="args">��������� ��������� ������, ���������� ����������.</param>
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}