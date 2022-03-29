using System.Collections.Generic;
using ViewConverterDemo.Data;
using ViewConverterDemo.Interfaces;
using ViewConverterDemo.Models;

namespace ViewConverterDemo.Client
{
    public class Controller
    {
        private readonly IProvider<StoreItem> provider = new Provider();

        public List<string> GetIDs() =>
            provider.GetIdList();

        public List<IdentityView> GetIdentities() =>
            provider.View<IdentityView>();
        
        public List<DetailView> GetItemDetails() =>
            provider.View<DetailView>();
    }
}
