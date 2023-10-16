using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TesteSmartHint.Domain.Enums
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> GetDictionary<T>()
        {
            var enums = Enum.GetValues(typeof(T)).OfType<T>();
            var result = new Dictionary<int, string>();

            foreach (var item in enums)
                result.Add(item.GetHashCode(), GetDisplayName(item));

            return result;
        }

        public static string GetDisplayName(object value)
        {
            return value.GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>
            (this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum selectedValue)
        {
            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem()
                                                {
                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = (value.Equals(selectedValue))
                                                };

            return SelectExtensions.DropDownListFor(htmlHelper, expression, items);
        }
    }
}
