using System;

namespace TablePerHierarchy.AbstractBaseClass
{
    public abstract class Contract
    {
        public int ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public int Months { get; set; }
        public decimal Charge { get; set; }
    }
    public class MobileContract : Contract
    {
        public string MobileNumber { get; set; }
    }
    public class TvContract : Contract
    {
        public PackageType PackageType { get; set; }
    }
    public class BroadbandContract : Contract
    {
        public int DownloadSpeed { get; set; }
    }
    public enum PackageType
    {
        S, M, L, XL
    }
}
