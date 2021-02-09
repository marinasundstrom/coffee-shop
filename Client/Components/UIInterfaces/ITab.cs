using Microsoft.AspNetCore.Components;

namespace App1.Client.Components.UIInterfaces
{
    public interface ITab
    {
        string Title { get; }

        RenderFragment ChildContent { get; }
    }
}
