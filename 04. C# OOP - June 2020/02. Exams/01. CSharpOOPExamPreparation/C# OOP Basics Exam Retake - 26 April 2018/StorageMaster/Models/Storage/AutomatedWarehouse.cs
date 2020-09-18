using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class AutomatedWarehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };
        public AutomatedWarehouse(string name) 
            : base(name, 1, 2, DefaultVehicles)
        {
        }
    }
}
