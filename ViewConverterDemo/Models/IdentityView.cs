using System.Collections.Generic;
using System.Linq;
using ViewConverterDemo.Interfaces;

namespace ViewConverterDemo.Models
{
    public class IdentityView : IConvertable<IdentityView, StoreItem>
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public List<IdentityView> Transform(IEnumerable<StoreItem> source)
        {
            return
                source.Select(item => new IdentityView
                {
                    ID = item.ID,
                    Name = item.ItemName,
                }).ToList();
        }
    }
}
