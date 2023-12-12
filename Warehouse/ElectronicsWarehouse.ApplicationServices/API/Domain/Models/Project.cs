namespace ElectronicsWarehouse.ApplicationServices.API.Domain.Models;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<string> ElectronicComponentsName { get; set; }
}
