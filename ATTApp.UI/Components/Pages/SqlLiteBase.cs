using ATTApp.Domin;
using ATTApp.UseCase;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace ATTApp.UI.Components.Pages
{
    public class SqlLiteBase : ComponentBase
    {
        public bool isDisabledStart = false;
        public bool isDisabledSave = true;
        public bool isDisabledXML = true;
        public bool isDisabledBinary = true;
        public bool save = false;
        public DisplayDTO display;

        [Inject]
        public LogicUseCase LogicUseCase { get; set; }

        [Inject]
        public SaveNumberUseCase SaveNumberUseCase { get; set; }
        [Inject]
        public GetNumberXMLUseCase GetNumberXMLUseCase { get; set; }
        [Inject]
        public IJSRuntime JSRunner { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        public void StartButton()
        {
            this.isDisabledStart = true;
            this.display = LogicUseCase.ExecuteSqlLite();
            this.isDisabledSave = false;
        }

        public void SaveButton()
        {
            this.isDisabledSave = true;
            this.save = this.SaveNumberUseCase.ExecuteSqlLite(this.display.list);
            if (save)
            {
                isDisabledXML = false;
                isDisabledBinary = false;
            }
        }


        public async Task XMLButton()
        {
            var xml = this.GetNumberXMLUseCase.ExecuteSqlLite();
            var fileName = "NumberRecords.xml";
            await JSRunner.InvokeVoidAsync("downloadFile", fileName, xml);
        }

        public void BinaryButton()
        {

        }


    }
}

