using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;

namespace App1.Client.Utils
{
    public class ServerSideValidator : ComponentBase
    {
        private ValidationMessageStore _messageStore = null!;

        [CascadingParameter] private EditContext CurrentEditContext { get; set; } = null!;

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException($"{nameof(ServerSideValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(ServerSideValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            _messageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => _messageStore.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => _messageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayErrors(IDictionary<string, IEnumerable<string>> errors)
        {
            foreach (KeyValuePair<string, IEnumerable<string>> err in errors)
            {
                _messageStore.Add(CurrentEditContext.Field(err.Key), err.Value);
            }
            CurrentEditContext.NotifyValidationStateChanged();
        }
    }
}