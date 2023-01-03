using fgciams.domain.clsEnums;

namespace fgciams.domain.clsVoucherRouteTag
{
    public class VoucherRouteTagModel
    {
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public Int64 VoucherId { get; set; }
        public Enums.RouteTag RouteTagId { get; set; }
        public bool IsRouted { get; set; }
    }
}