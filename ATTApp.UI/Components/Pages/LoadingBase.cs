using Microsoft.AspNetCore.Components;

namespace ATTApp.UI.Components.Pages
{
    public class LoadingBase : ComponentBase
    {
        [Parameter] public bool IsLoading { get; set; }
        [Parameter] public string LoadingText { get; set; } = "Loading...";
        [Parameter] public RenderFragment LoadingTemplate { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
