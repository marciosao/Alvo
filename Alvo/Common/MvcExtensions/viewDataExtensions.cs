using System;
using System.Linq;
using System.Web.Mvc;

namespace Alvo.Common.MvcExtensions
{
  
        public static class ViewDataExtensions
        {
            public static TAttribute GetModelAttribute<TAttribute>(this ViewDataDictionary viewData, bool inherit = false) where TAttribute : Attribute
            {
                if (viewData == null) throw new ArgumentException("ViewData");
                var containerType = viewData.ModelMetadata.ContainerType;
                return
                    ((TAttribute[])
                     containerType.GetProperty(viewData.ModelMetadata.PropertyName).GetCustomAttributes(typeof(TAttribute),
                                                                                                        inherit)).
                        FirstOrDefault();

            }
        }
    }
