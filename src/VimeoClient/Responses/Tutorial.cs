using System;
using System.Collections.Generic;
using System.Text;
namespace VimeoClient.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class Tutorial
    {
        public string message { get; set; }
        public string next_steps_link { get; set; }
        public bool token_is_authenticated { get; set; }
    }
}
