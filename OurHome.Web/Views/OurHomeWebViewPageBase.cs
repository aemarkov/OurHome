using Abp.Web.Mvc.Views;

namespace OurHome.Web.Views
{
    public abstract class OurHomeWebViewPageBase : OurHomeWebViewPageBase<dynamic>
    {

    }

    public abstract class OurHomeWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected OurHomeWebViewPageBase()
        {
            LocalizationSourceName = OurHomeConsts.LocalizationSourceName;
        }
    }
}