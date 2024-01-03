using System.Collections.Generic;

namespace BlazorAppWarehouse.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> ElectronicComponentsName { get; set; }
    }
}