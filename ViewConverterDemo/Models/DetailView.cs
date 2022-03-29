using System.Collections.Generic;
using System.Linq;
using ViewConverterDemo.Interfaces;

namespace ViewConverterDemo.Models
{
    public class DetailView : IConvertable<DetailView, StoreItem>
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DetailView> Transform(IEnumerable<StoreItem> source)
        {
            return
                source.Select(item => new DetailView
                {
                    ID = item.ID,
                    Name = item.ItemName,
                    Description = item.Description,
                }).ToList();
        }
    }
}
