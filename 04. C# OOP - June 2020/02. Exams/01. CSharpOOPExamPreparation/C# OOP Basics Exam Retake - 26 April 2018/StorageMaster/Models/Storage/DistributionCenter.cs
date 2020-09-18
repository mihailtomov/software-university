using StorageMaster.Models.Vehicles;

namespace StorageMaster.Models.Storage
{
    public class DistributionCenter : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };
        public DistributionCenter(string name) 
            : base(name, 2, 5, DefaultVehicles)
        {
        }
    }
}
