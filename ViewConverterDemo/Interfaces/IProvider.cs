using System;
using System.Collections.Generic;

namespace ViewConverterDemo.Interfaces
{
    public interface IProvider<TEntity> : ITransformable<TEntity>
    {
        List<string> GetIdList();

        List<TEntity> GetList();
    }
    
    public interface ITransformable<TSource>
    {
        List<TViewModel> View<TViewModel>()
            where TViewModel : IConvertable<TViewModel, TSource>, new();
    }
}
