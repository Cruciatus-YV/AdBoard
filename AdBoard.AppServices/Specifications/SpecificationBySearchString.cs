using Abp.Linq.Expressions;
using AdBoard.AppServices.Specifications;
using AdBoard.Domain.Base;
using System.Linq.Expressions;

namespace AdBoard.AppServices.Specifications;

/// <summary>
/// Спецификация для поиска товаров через поисковую строку.
/// Возвращает продукты, у которых название или описание содержит заданную строку, 
/// без учёта регистра.
/// </summary>
public class SpecificationBySearchString<TEntity> : Specification<TEntity> where TEntity : class
{
    private readonly string _searchString;
    private readonly bool _searchOnlyByName;

    /// <summary>
    /// Инициализирует новый экземпляр спецификации поиска товаров.
    /// </summary>
    /// <param name="searchString">Поисковая строка.</param>
    public SpecificationBySearchString(string searchString, bool searchOnlyByName)
    {
        _searchString = searchString?.ToLower();
        _searchOnlyByName = searchOnlyByName;
    }

    ///// <summary>
    ///// Выражение для фильтрации товаров по названию или описанию, содержащим поисковую строку.
    ///// </summary>
    public override Expression<Func<TEntity, bool>> PredicateExpression
    {
        get
        {
            Expression<Func<TEntity, bool>> expr = entity => true;

            if (_searchOnlyByName && typeof(IHaveName).IsAssignableFrom(typeof(TEntity)))
            {
                expr = expr.And(entity => ((IHaveName)entity).Name.ToLower().Contains(_searchString));
                return expr;
            }

            if (typeof(IHaveName).IsAssignableFrom(typeof(TEntity)) && typeof(IHaveDescription).IsAssignableFrom(typeof(TEntity)))
            {
                expr = expr.And(entity => ((IHaveName)entity).Name.ToLower().Contains(_searchString) || ((IHaveDescription)entity).Description.ToLower().Contains(_searchString));
            }
            else if (typeof(IHaveName).IsAssignableFrom(typeof(TEntity)))
            {
                expr = expr.And(entity => ((IHaveName)entity).Name.ToLower().Contains(_searchString));
            }
            else if (typeof(IHaveDescription).IsAssignableFrom(typeof(TEntity)))
            {
                expr = expr.And(entity => ((IHaveDescription)entity).Description.ToLower().Contains(_searchString));
            }

            return expr;
        }
    }
}