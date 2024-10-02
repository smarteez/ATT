using ATTApp.Domin;
using ATTApp.UseCase;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;
using System;


namespace ATTApp.UI.Components.Pages
{
    public class SqlBase : ComponentBase
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
        public GetNumberBinaryUseCase GetNumberBinaryUseCase { get; set ; }
        [Inject]
        public IJSRuntime JSRunner { get; set; }
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
        }

        public void StartButton()
        {
            this.isDisabledStart = true;
            this.display = LogicUseCase.ExecuteSql();
            this.isDisabledSave = false;
        }

        public void SaveButton()
        {
            this.isDisabledSave = true;
            this.save = this.SaveNumberUseCase.ExecuteSql(this.display.list);
            if (save)
            {
                isDisabledXML = false;
                isDisabledBinary = false;
            }
        }

        public async Task XMLButton()
        {
            var xml = this.GetNumberXMLUseCase.ExecuteSql();
            var fileName = "NumberRecords.xml";
            await JSRunner.InvokeVoidAsync("downloadFile", fileName, xml);
        }

        public async Task BinaryButton()
        {
            var binaryData = this.GetNumberBinaryUseCase.ExecuteSql();
            var fileName = "NumberRecords.bin";
            await JSRunner.InvokeVoidAsync("downloadFile", fileName, binaryData);
        }


    }
}
