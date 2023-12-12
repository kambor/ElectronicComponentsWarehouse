namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Responses;

public class ErrorModel
{
    public ErrorModel(string error)
    {
        this.Error = error;
    }

    public string Error { get; set; }
}
