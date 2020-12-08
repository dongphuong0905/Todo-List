using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoList.Models
{
    public partial class Todo
    {
        public int TodoID { get; set; }
        public string TodoValue { get; set; }
        public string TodoCreateTime { get; set; }
        public string TodoStatus { get; set; }
    }
}
