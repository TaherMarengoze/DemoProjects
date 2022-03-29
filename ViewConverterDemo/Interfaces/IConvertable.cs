using System.Collections.Generic;

namespace ViewConverterDemo.Interfaces
{
    public interface IConvertable<TOut, TSource>
    {
        List<TOut> Transform(IEnumerable<TSource> source);
    }
}