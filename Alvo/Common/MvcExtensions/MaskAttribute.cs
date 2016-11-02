using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Common.MvcExtensions
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaskAttribute : Attribute, IMetadataAware
    {
        private string _mask = string.Empty;
        private string _atributo = string.Empty;
        public MaskAttribute(string mask, string atributo)
        {
            _mask = mask;
            _atributo = atributo;
        }

        public string Mask
        {
            get { return _mask; }
        }

        private const string ScriptText = "<script type='text/javascript'>" +
                                           "$(document).ready(function () {{" +
                                           "$('#{0}').inputmask('{1}');}});</script>";

        public const string templateHint = "_maskedInput";

        private int _count;

        public string Id
        {
            get { return "maskedInput_" + _count; }
        }

        internal HttpContextBase Context
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            var list = Context.Items["Scripts"] as IList<string> ?? new List<string>();
            _count = list.Count;
            metadata.TemplateHint = templateHint;
            metadata.AdditionalValues[templateHint] = Id;
            list.Add(string.Format(ScriptText, _atributo, Mask));

            Context.Items["Scripts"] = list;
        }
    }
}
