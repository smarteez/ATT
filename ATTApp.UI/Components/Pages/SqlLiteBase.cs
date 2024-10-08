﻿using ATTApp.Domin;
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
        public bool isProcessing = false;

        [Inject]
        public LogicUseCase LogicUseCase { get; set; }

        [Inject]
        public SaveNumberUseCase SaveNumberUseCase { get; set; }
        [Inject]
        public GetNumberXMLUseCase GetNumberXMLUseCase { get; set; }
        [Inject]
        public GetNumberBinaryUseCase GetNumberBinaryUseCase { get; set; }
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

        public async Task SaveButton()
        {
            try
            {
                this.isDisabledSave = true;
                isProcessing = true;
                Console.WriteLine("Starting save operation...");
                await InvokeAsync(StateHasChanged);

                this.save = await Task.Run(() => this.SaveNumberUseCase.ExecuteSqlLite(this.display.list));

                if (save)
                {
                    isDisabledXML = false;
                    isDisabledBinary = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                isProcessing = false;
                Console.WriteLine("Save operation completed.");
                await InvokeAsync(StateHasChanged);
            }
        }




        public async Task XMLButton()
        {
            var xml = this.GetNumberXMLUseCase.ExecuteSqlLite();
            var fileName = "NumberRecords.xml";
            await JSRunner.InvokeVoidAsync("downloadFile", fileName, xml);
        }

        public async Task BinaryButton()
        {
            var binaryData = this.GetNumberBinaryUseCase.ExecuteSqlLite();
            var fileName = "NumberRecords.bin";
            await JSRunner.InvokeVoidAsync("downloadFile", fileName, binaryData);
        }


    }
}

