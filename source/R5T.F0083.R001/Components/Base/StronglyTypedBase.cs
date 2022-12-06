using System;

using Microsoft.AspNetCore.Components;


namespace R5T.F0083.R001.Internal
{
    public class StronglyTypedBase : ComponentBase
    {
        [Parameter]
        public string NamespaceName { get; set; }

        [Parameter]
        public string TypeName { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public bool IsDraft { get; set; }

        public string DraftString { get; set; }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            this.DraftString = this.IsDraft
                ? "Draft"
                : String.Empty
                ;
        }
    }
}
