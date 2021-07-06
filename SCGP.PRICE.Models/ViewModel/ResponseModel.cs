using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Models.ViewModel
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        private string _message;
        public string Message { get => Errors.Count > 0 ? "" : _message; set => _message = value; }
        public List<string> Errors { get; set; }
        public object data { get; set; }
        public ResponseModel()
        {
            Success = true;
            Errors = new List<string>();
            _message = "Normal completed";
        }
    }
}
