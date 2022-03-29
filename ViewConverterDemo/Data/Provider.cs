using System;
using System.Collections.Generic;
using ViewConverterDemo.Interfaces;
using ViewConverterDemo.Models;

namespace ViewConverterDemo.Data
{
    public class Provider : IProvider<StoreItem>
    {
        private readonly List<StoreItem> storeItems = new List<StoreItem>
        {
            new StoreItem{ ID="001", ItemName="Item 1", Description="Description 1", CategoryID="C01" },
            new StoreItem{ ID="002", ItemName="Item 2", Description="Description 2", CategoryID="C01" },
            new StoreItem{ ID="003", ItemName="Item 3", Description="Description 3", CategoryID="C01" },
        };

        public List<string> GetIdList()
        {
            throw new NotImplementedException();
        }

        public List<StoreItem> GetList()
        {
            return storeItems;
        }
        
        public List<TViewModel> View<TViewModel>()
            where TViewModel : IConvertable<TViewModel, StoreItem>, new()
        {
            TViewModel adapter = new TViewModel();
            return adapter.Transform(storeItems);
        }
    }
}
