using Mirror.Common.Model;

namespace Mirror.Data.Entities
{
    public class ActiveVendor : Adaptable<Vendor>
    {
        public ActiveVendor(Vendor from) : base(from)
        {
            Url = from.Url;
        }

        public string Url { get; set; }

        public override Vendor ToAdaptable() => new Vendor
        {
            Url = Url
        };
    }
}