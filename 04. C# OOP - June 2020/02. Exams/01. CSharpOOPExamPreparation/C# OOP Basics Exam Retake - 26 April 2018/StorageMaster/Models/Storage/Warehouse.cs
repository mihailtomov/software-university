using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class Warehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Semi(),
            new Semi(),
            new Semi()
        };
        public Warehouse(string name) 
            : base(name, 10, 10, DefaultVehicles)
        {
        }
    }
}
