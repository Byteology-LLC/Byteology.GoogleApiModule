using AutoMapper;
using GoogleApi.Entities.Interfaces;
using Volo.Abp.AutoMapper;

namespace Byteology.GoogleApiModule.Extensions
{
    public static class GoogleApisAutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreOptionedValues<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
            where TDestination : IRequest
        {
            return mappingExpression.Ignore(x => x.ClientId).Ignore(x => x.Key);
        }
    }
}
